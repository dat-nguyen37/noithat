<template>
    <div class="min-h-[60vh] mt-2 relative">
        <div class="flex justify-between px-4">
            <h1 class="font-bold uppercase">User</h1>
        </div>
        <div class="bg-white shadow-lg mt-1">
            <table class="w-full">
                <thead class="border">
                    <tr class="bg-gray-400">
                        <th scope="col" class="border">Gmail</th>
                        <th scope="col" class="border">Admin</th>
                        <th scope="col" class="border">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in data" :key="item.id">
                        <td scope="col" class="border text-center">{{ item.email }}</td>
                        <td scope="col" class="border text-center">
                            <input type="checkbox" v-model="item.role">
                        </td>
                        <td scope="col" class="text-red-500 border text-center text-xl">
                            <VueIcon type="mdi" :path="mdiTrashCanOutline"  class="text-red-500 mx-2 hover:cursor-pointer" @click="handleDelete(item.id)"/>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import {mdiTrashCanOutline} from "@mdi/js"
export default {
    name:'CategoryView',
    props:['updateUser'],
    data(){
        return{
            data:"",
            page:1,
            limit:5,
            mdiTrashCanOutline
        }
    },
    created(){
        this.getuser();
    },
    methods:{
        async getuser(){
            try {
                const res=await axios.get(`/User/getByPage?page=${this.page}&limit=${this.limit}`)
                this.data=res.data
            } catch (err) {
                console.log(err)
            }
        },
    },
}
</script>