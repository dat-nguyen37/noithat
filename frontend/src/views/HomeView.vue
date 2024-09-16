<template>
    <div class="flex flex-col min-h-screen">
        <div class="overflow-hidden relative flex items-center">
            <div id="slider" class="flex w-screen transition-all duration-500" :style="{ transform: `translateX(-${currentIndex * 100}%)` }">
                <img src="/assets/slider/slide1.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide2.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide3.webp" alt="" class="min-w-full h-[25vh] md:h-[50vh]">                
                <img src="/assets/slider/slide4.jpg" alt="" class="min-w-full h-[25vh] md:h-[50vh]">     
            </div>
            <div @click="prevSlide" class="absolute left-0 cursor-pointer animate-pulse text-black"><VueIcon type="mdi" :path="mdiChevronLeft" size="70"/></div>           
            <div @click="nextSlide" class="absolute right-0 cursor-pointer animate-pulse text-black"><VueIcon type="mdi" :path="mdiChevronRight" size="70"/></div>           
        </div>
        <div class="grid grid-cols-1 md:grid-cols-2 gap-5 py-2">
            <div class="flex flex-col items-center gap-5 p-10">
                <h1 class="uppercase text-3xl font-bold">NỘI THẤT TINH TẾ</h1>
                <p>Với kinh nghiệm hơn 24 năm trong hoàn thiện nội thất, Nhà Xinh mang đến giải pháp toàn diện trong bao gồm thiết kế, trang trí và cung cấp nội thất trọn gói. Sở hữu đội ngũ chuyên nghiệp và hệ thống 10 cửa hàng, Nhà Xinh là lựa chọn cho không gian tinh tế và hiện đại.</p>
                <a href="" class="border-2 p-2 border-green-500 text-xl font-bold hover:text-white hover:bg-green-500">Xem thêm</a>
            </div>
            <div class="">
                <img src="/assets/image/thietke.jpg" alt="w-full h-full object-cover">
            </div>
        </div>
        <div class="flex flex-col p-5">
            <!-- new -->
            <div class="flex flex-col gap-2">
                <h1 class="text-3xl font-medium">Mới nhất</h1>
                <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                    <ProductItem/>
                    <ProductItem/>
                    <ProductItem/>
                    <ProductItem/>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiChevronRight,mdiChevronLeft} from '@mdi/js'
import ProductItem from '@/components/productItem/ProductItem.vue';
export default {
    name:"HomeView",
    components:{ProductItem},
    data(){
        return{
            currentIndex:0,
            slidesCount: 4,
            mdiChevronRight,mdiChevronLeft
        }
    },
    mounted(){
        this.startAutoSlide()
    },
    methods: {
        nextSlide() {
            this.currentIndex = (this.currentIndex + 1) % this.slidesCount;
        },
        prevSlide() {
            this.currentIndex = (this.currentIndex - 1 + this.slidesCount) % this.slidesCount;
        },
        startAutoSlide(){
            setInterval(()=>{
                this.nextSlide()
        },3000)
        }
    }
}
</script>