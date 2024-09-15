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
    </div>
</template>

<script>
import {mdiChevronRight,mdiChevronLeft} from '@mdi/js'
export default {
    name:"HomeView",
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