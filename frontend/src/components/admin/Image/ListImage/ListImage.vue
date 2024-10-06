<template>
    <div class="p-5">
        <div class="flex justify-between gap-2 px-4">
            <router-link :to="{name:'imageCollection'}" class="flex items-center gap-2"><VueIcon type="mdi" :path="mdiKeyboardBackspace"/>Quay lại</router-link>
            <label for="file" class="bg-blue-400 p-2 rounded-sm  shadow-lg cursor-pointer">Upload ảnh</label>
            <input type="file" hidden id="file" name="image" @change="handleImageChange">
        </div>
        <div class="grid grid-cols-12 gap-2 py-5">
            <div v-for="item in listImages" :key="item.productImageId" class="col-span-4 sm:col-span-3 md:col-span-2 border-2">
                <div class="relative" v-viewer>
                    <img :src="item.imageUrl" alt="" class="w-full h-full">
                    <div @click="Delete(item.productImageId)" class="absolute top-0 right-0 cursor-pointer border-b rounded-full bg-gray-300"><VueIcon type="mdi" :path="mdiClose" size="20" /></div>
                </div>
                <viewer :src="item.imageUrl">
                    <img :src="src">
                </viewer>
            </div>
        </div>
    </div>
</template>
<script>
import {mdiClose, mdiKeyboardBackspace} from "@mdi/js"
import {imgDb} from '../../../../firebase'
import { ref, uploadBytesResumable,getDownloadURL } from 'firebase/storage'
import axios from "axios";
export default {
    name:"ListImage",
    data(){
        return{
            mdiKeyboardBackspace,mdiClose,
            productId:this.$route.params.id,
            image:"",
            listImages:""
        }
    },
    watch:{
        "$route.params.id":function(newValue){
            this.productId=newValue
        }
    },
    mounted(){
        this.getImage()
    },
    methods:{
        async handleImageChange(event) {
            const file = event.target.files[0];
            if (!file) return;
            try {
                const imgRef = ref(imgDb, `/product/${this.productId}/${file.name}`);
                const uploadTask = uploadBytesResumable(imgRef, file);
                uploadTask.on(
                    "state_changed",
                    (snapshot) => {
                        this.percent = Math.round((snapshot.bytesTransferred / snapshot.totalBytes) * 100);
                    },
                    (err) => console.log(err),
                    async () => {
                        const url = await getDownloadURL(uploadTask.snapshot.ref);
                        this.image = url;
                        if(this.image){
                            try {
                                await axios.post("/ProductImage/create",{
                                    imageUrl:this.image,
                                    productId:this.productId
                                })
                                this.getImage()
                                alert("Upload thành công");
                            } catch (err) {
                                console.log(err)
                            }
                        }
                    }
                );
            } catch (err) {
                console.error("Error uploading image:", err);
            }
        },
        async getImage(){
            try {
                const res=await axios.get(`/ProductImage/getByProduct/${this.productId}`)
                this.listImages=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async Delete(id){
            try {
                await axios.delete(`/ProductImage/delete/${id}`)
                this.getImage()
            } catch (err) {
                console.log(err)
            }
        }
    }
}
</script>