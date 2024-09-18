<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/<a href=""> Danh mục </a>/<p class="line-clamp-1">Nội Thất Phòng Ngủ</p>
        </div>
        <img src="/assets/slider/slide1.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">
        <div class="flex flex-col gap-5 p-5 md:p-10">
            <h1 class="font-bold text-base sm:text-xl md:text-3xl">Nội Thất Phòng Ngủ</h1>
            <div class="grid sm:grid-cols-2 lg:grid-cols-4 items-center gap-10 text-sm sm::text-base">
                <select name="" id="" class="border-b outline-none p-2">
                    <option value="">Sản phẩm nổi bật</option>
                    <option value="">Giá: Tăng dần</option>
                    <option value="">Giá: Giảm dần</option>
                    <option value="">Mới nhất</option>
                    <option value="">Bán chạy nhất</option>
                </select>
                <select name="" id="" class="border-b outline-none p-2">
                    <option value="">Giá sản phẩm</option>
                    <option value="">Dưới 500,000₫</option>
                    <option value="">500,000₫ - 1,000,000₫</option>
                    <option value="">1,000,000₫ - 2,000,000₫</option>
                    <option value="">2,000,000₫ - 5,000,000₫</option>
                    <option value="">Trên 5,000,000₫</option>
                </select>
                <div class="flex items-center justify-between  border-b p-2  relative group">
                    <p>Màu sắc: {{ selectColor }}</p>
                    <VueIcon type="mdi" :path="mdiChevronDown"/>
                    <div class="absolute -z-10 opacity-0 ease-in-out duration-700 translate-y-40 transform group-hover:z-10 group-hover:translate-y-10 group-hover:opacity-100 top-0 border w-full left-0 p-2 text-sm text-gray-500 bg-white">
                        <div class="flex gap-3 flex-wrap">
                            <li v-for="(color,index) in colors" :key="index" class="list-none">
                                <label @click="selectedColor(color.name)" :style="{ backgroundColor: color.hex }" :class="selectColor === color.name ? 'border-2 border-gray-700' :''" class="w-6 h-6 rounded-full inline-block cursor-pointer"></label>
                            </li>
                        </div>
                    </div>
                </div>
                <div class="flex items-center justify-between  border-b p-2  relative group">
                    <p>Kích thước:{{ selectSize }}</p>
                    <VueIcon type="mdi" :path="mdiChevronDown"/>
                    <ul class="absolute -z-10 opacity-0 ease-in-out duration-700 translate-y-40 transform group-hover:z-10 group-hover:translate-y-10 group-hover:opacity-100 top-0 border w-full left-0 p-2 text-sm text-gray-500 bg-white">
                        <div class="flex flex-wrap gap-2 p-2">
                            <div @click="selectedSize('90cm')"  :class="selectSize==='90cm' && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">90cm</div>
                            <div @click="selectedSize('1m2')" :class="selectSize==='1m2' && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">1m2</div>
                            <div @click="selectedSize('1m4')" :class="selectSize==='1m4' && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">1m4</div>
                            <div @click="selectedSize('1m6')" :class="selectSize==='1m6' && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">1m6</div>
                            <div @click="selectedSize('1m8')" :class="selectSize==='1m8' && 'border-2 bg-gray-200'" class="p-2 border cursor-pointer">1m8</div>
                        </div>
                    </ul>
                </div>
            </div>
            <div class="flex gap-5">
                <div class="flex gap-2 flex-wrap ">
                    <div v-if="selectSize" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 rounded-md">Kích thước: <b>{{ selectSize }}</b>
                        <VueIcon @click="deleteSize" type="mdi" :path="mdiClose" class="cursor-pointer"/>
                    </div>  
                    <div v-if="selectColor" class="flex px-1 items-center gap-1 w-auto text-sm border text-gray-500 rounded-md">Màu sắc: <b>{{ selectColor }}</b>
                        <VueIcon @click="deleteColor" type="mdi" :path="mdiClose" class="cursor-pointer"/>
                    </div>
                </div>
            </div>
            <div class="sm:w-40 text-center p-2 uppercase text-white bg-black cursor-pointer">Áp dụng</div>
            <div>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem v-for="item in 12" :key="item"/>
                </div>
                <div class="flex justify-center gap-5 text-gray-500 items-center">
                    <VueIcon type="mdi" :path="mdiArrowLeftThin" size="30" class="hover:text-black cursor-pointer"/>
                    <a href="" class="hover:text-black">1</a>
                    <a href="" class="hover:text-black">2</a>
                    <a href="" class="hover:text-black">3</a>
                    <a href="" class="hover:text-black">4</a>
                    <span>...</span>
                    <a href="" class="hover:text-black">7</a>
                    <VueIcon type="mdi" :path="mdiArrowRightThin" size="30" class="hover:text-black cursor-pointer"/>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiChevronDown, mdiClose, mdiFilterOutline,mdiArrowRightThin,mdiArrowLeftThin} from "@mdi/js"
import data from "../color.json"
import ProductItem from "@/components/productItem/ProductItem.vue";
export default {
    name:"DepartmentView",
    components:{ProductItem},
    data(){
        return{
            colors:data,
            mdiFilterOutline,mdiChevronDown,mdiClose,mdiArrowRightThin,mdiArrowLeftThin,
            selectColor:"",
            selectSize:"",
            sort:"",
        }
    },
    methods:{
        
        selectedColor(color){
            this.selectColor=color
        },
        selectedSize(size){
            this.selectSize=size
        }
    }

}
</script>