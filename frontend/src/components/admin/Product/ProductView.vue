<template>
    <div class=" mt-2 relative">
        <div class="flex justify-between px-4">
            <h1 class="font-bold uppercase">Product</h1>
            <button class="bg-blue-400 p-2 rounded-sm z-10 shadow-lg" @click="handleAdd">Add product</button>
        </div>
        <div class="bg-white shadow-lg mt-1">
            <table class="w-full">
                <thead class="border">
                    <tr class="bg-gray-400">
                        <th scope="col" class="border">Name</th>
                        <th scope="col" class="border">Price</th>
                        <th scope="col" class="border">Image</th>
                        <th scope="col" class="border">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item._id">
                        <td scope="col" class="border text-center">{{item.name}}</td>
                        <td scope="col" class="border text-center">{{ item.price }}</td>
                        <td scope="col" class="border text-center">
                            <div class="flex justify-center" v-viewer>
                                <img :src="item.image" class="w-10 h-10" alt="">
                            </div>
                            <viewer :src="item.image">
                                <img :src="src">
                            </viewer>
                        </td>
                        <td scope="col" class="border text-center">
                            <div class="flex items-center justify-center gap-2">
                                <div>
                                    <VueIcon type="mdi" :path="mdiTextBoxEditOutline" class="text-blue-500 hover:cursor-pointer" />
                                </div>
                                <div @click="handleDelete(item.categoryId)">
                                    <VueIcon type="mdi" :path="mdiTrashCanOutline"  class="text-red-500 hover:cursor-pointer"/>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!-- <div class="absolute bottom-0 right-0">
            <div class="flex gap-2">
                <font-awesome-icon icon="arrow-left" v-if="page>1" @click="prevPage" class="p-2 bg-blue-400 hover:cursor-pointer"/>
                <font-awesome-icon icon="arrow-right" @click="nextPage" class="p-2 bg-blue-400 hover:cursor-pointer"/>
            </div>
        </div> -->
        <AddProduct :open="add" @close="handleClose" :getproduct="getproduct"/>
        <EditProduct :open="update" :productIdToUpdate="productIdToUpdate" @close="handleClose" @update="handleLoad"/>
    </div>
</template>
<script>
import AddProduct from './AddProduct.vue'
import EditProduct from './EditProduct.vue'

import axios from 'axios'
import {mdiTrashCanOutline,mdiTextBoxEditOutline} from "@mdi/js"
export default {
    name:'ProductView',
    components:{AddProduct,EditProduct},
    props:['updateProduct'],
    data(){
        return{
            add:false,
            update:false,
            data:[],
            page:1,
            limit:5,
            productIdToUpdate:'',
            mdiTrashCanOutline,mdiTextBoxEditOutline
        }
    },
    created(){
        this.getproduct()
    },
    methods:{
        async getproduct(){
            try {
                const res=await axios.get(`/product/getByPage?page=${this.page}&limit=${this.limit}`)
                this.data=res.data
            } catch (err) {
                console.error(err)
            }
        },
        async handledelete(id){
            try {
                await axios.delete(`product/delete/${id}`)
                this.getproduct()
            } catch (err) {
                alert('Lỗi')
            }
        },
        handleLoad(){
            this.getproduct()
        },
        handleAdd(){
            this.add=true;
        },
        handleUpdate(id){
            this.update=true;
            this.productIdToUpdate = id;
        },
        handleClose(){
            this.add = false;
            this.update = false;
        },
        async prevPage(){
            if (this.page > 1) {
                this.page--;
                await this.getproduct();
            }
        },
        async nextPage() {
            this.page++;
            await this.getproduct();
        }
    }
}
</script>