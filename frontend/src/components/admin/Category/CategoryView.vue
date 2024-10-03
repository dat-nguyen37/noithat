<template>
    <div class=" mt-2">
        <div class="flex justify-between px-4">
            <h1 class="font-bold uppercase">Category</h1>
            <button class="bg-blue-400 p-2 rounded-sm z-10 shadow-lg" @click="handleAdd">Add category</button>
        </div>
        <div class="bg-white shadow-lg mt-1">
            <table class="w-full">
                <thead class="border">
                    <tr class="bg-gray-400">
                        <th scope="col" class="border">Name</th>
                        <th scope="col" class="border">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item.categoryId">
                        <td scope="col" class="border text-center">{{ item.name }}</td>
                        <td scope="col" class=" border flex items-center justify-center gap-2">
                            <VueIcon type="mdi" :path="mdiTextBoxEditOutline" class="text-blue-500 hover:cursor-pointer" />
                            <div @click="handleDelete(item.categoryId)"><VueIcon type="mdi" :path="mdiTrashCanOutline"  class="text-red-500 hover:cursor-pointer"/></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <AddCategory :open="add" :getcategory="getcategory" @close="handleClose"/>
    </div>
</template>
<script>
import axios from 'axios'
import AddCategory from './AddCategory.vue'
import { mdiTextBoxEditOutline,mdiTrashCanOutline } from '@mdi/js';

export default {
    name:'CategoryView',
    components:{AddCategory},
    data(){
        return{
            add:false,
            data:[],
            page:1,
            limit:5,
            mdiTextBoxEditOutline,mdiTrashCanOutline
        }
    },
    created(){
        this.getcategory();
    },
    methods:{
        async getcategory(){
            try {
                const res=await axios.get(`https://localhost:7224/Category/getByPage?page=${this.page}&limit=${this.limit}`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async handleDelete(id){
            try {
                await axios.delete('https://localhost:7224/Category/delete/'+id)
                this.getcategory();
                alert("Xóa thành công")
            } catch (err) {
                console.log(err)
            }
        },
        handleAdd(){
            this.add=true;
        },
        handleClose(){
            this.add = false;
        },
    },
}
</script>