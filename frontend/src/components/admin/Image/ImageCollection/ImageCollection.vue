<template>
    <div class="w-full h-full p-5">
        <div class="flex justify-between px-4">
            <h1 class="font-bold uppercase">Danh sách</h1>
        </div>
        <div class="grid grid-cols-12 gap-2 py-5">
            <div v-for="item in data" :key="item.productId" class="col-span-4 sm:col-span-3 md:col-span-2 p-2 hover:bg-gray-200">
                <router-link :to="{name:'listImage',params:{id:item.productId}}" class="flex flex-col items-center">
                    <VueIcon type="mdi" :path="mdiFolderImage" size="40" class="text-orange-500"/>
                    <span class="text-xs sm:text-sm text-center line-clamp-2">{{ item.name }}</span>
                </router-link>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiFolderImage} from "@mdi/js"
import axios from "axios";
export default {
    name:"ImageCollection",
    data(){
        return{
            mdiFolderImage,
            data:""
        }
    },
    mounted(){
        this.getproduct()
    },
    methods:{
        async getproduct(){
            try {
                const res=await axios.get(`/product/getAll`)
                this.data=res.data
            } catch (err) {
                console.error(err)
            }
        },
    }
}
</script>