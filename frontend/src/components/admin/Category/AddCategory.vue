<template>
    <div v-if="open" class="fixed flex justify-center items-center z-20 inset-0 bg-black bg-opacity-50 h-[100vh] w-[100vw]" >
        <div  class=" bg-white w-full md:w-1/2">
            <div class="text-center relative">
                <h1 class="uppercase font-bold text-xl bg-[#271511] text-white p-2">Add Category</h1>
                <div @click="close">
                    <VueIcon type="mdi" :path="mdiClose" size="30" class="absolute top-0 right-0 hover:cursor-pointer text-white  hover:bg-red-500"/>
                </div>
            </div>
            <div class="flex flex-col gap-5 p-5">
                <input type="text" name="name" v-model="name" placeholder="Name category" class="border-b w-full p-2">
                <div class="flex gap-5">
                    <select name="" id="" v-model="categoryTypeId" class="p-2 w-40 h-10 border outline-none">
                        <option value="0" selected>Danh mục</option>
                        <option v-for="item in categoryType" :key="item.categoryTypeId" :value="item.categoryTypeId">{{ item.name }}</option>
                    </select>
                    <div class="flex">
                        <label v-if="!image" for="file" class="w-10 h-10 md:w-20 md:h-20 border-2 flex justify-center items-center hover:cursor-pointer"><VueIcon type="mdi" :path="mdiCamera" class=""/></label>
                        <div v-else class="relative">
                            <img :src="image" alt="" class="w-10 h-10 md:w-20 md:h-20 border-2 text-2xl block hover:cursor-pointer">
                            <div @click="remove">
                                <VueIcon type="mdi" :path="mdiClose" class="absolute top-0 right-0 p-1 hover:cursor-pointer border bg-slate-100 rounded-[50%]"/>
                            </div>
                        </div>
                            <input type="file" hidden id="file" name="image" @change="handleImageChange">
                    </div>
                </div>
                <button @click="AddCategory" class="float-end p-2 bg-blue-400 shadow-md z-10 rounded-md">Add Category</button>
            </div>
        </div>
    </div>

</template>
<script>
import { mdiCamera, mdiClose } from '@mdi/js';
// import axios from 'axios'
import { ref, uploadBytesResumable,getDownloadURL } from 'firebase/storage'
import { imgDb } from '@/firebase';
import axios from 'axios';

export default {
    name:"AddCategory",
    props:['open','getcategory'],
    data(){
        return{
            name:'',
            image:"",
            categoryTypeId:0,
            mdiClose,mdiCamera,
            percent:0,
            categoryType:""
        }
    },
    mounted(){
        this.getCategoryType()
    },
    methods:{
        close(){
            this.$emit('close');
        },
        remove(){
            this.image=''
        },
        async handleImageChange(event) {
            const file = event.target.files[0];
            if (!file) return;
            try {
                const imgRef = ref(imgDb, `/logo/${file.name}`);
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
                    }
                );
            } catch (err) {
                console.error("Error uploading image:", err);
            }
        },
        async getCategoryType(){
            try {
                const res=await axios.get("/CategoryType/getAll")
                this.categoryType=res.data
            } catch (err) {
                console.log(err)
            }
        },
        async AddCategory(){
            try {
                await axios.post("/Category/create",{
                    name:this.name,
                    image:this.image,
                    categoryTypeId:this.categoryTypeId
                })
                this.getcategory()
                alert("Thêm thành công")
            } catch (err) {
                console.log(err)
            }
        }
    }
}
</script>