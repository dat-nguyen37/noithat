<template>
    <div class="flex flex-col gap-2 border">
        <div class="relative w-full">
            <router-link :to="{name:'productdetail',params:{id: item.productId}}" class=""><img :src="item.image" :alt="item.name" width="480" height="480" class="object-cover"></router-link>
            <div class="absolute px-2 top-0 left-0 bg-red-500 text-white">-{{item.discounted}}%</div>
            <!-- <div class="absolute px-2 top-0 right-0 bg-orange-500 text-white">NEW</div> -->
        </div>
        <div class="px-2">
            <p class="uppercase text-[12px] sm:text-sm font-semibold">{{item.name}}</p>
            <p class="text-red-500 text-[12px] sm:text-base">{{item.finalPrice | numeral}}<u>đ</u>&nbsp;<s class="text-gray-400">{{item.price | numeral}}<u>đ</u></s></p>
            <div class="flex flex-col md:flex-row justify-between">
                <div class="flex">
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <p>(27)</p>
                </div>
                <div class="flex flex-col">
                    <p class="text-[12px] sm:text-base">Đã bán {{ item.sell || 0 }}</p>
                    <VueIcon type="mdi" :path="mdiHeartOutline" class="md:self-end"/>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiStar, mdiHeartOutline} from '@mdi/js'

export default {
    name:"ProductItem",
    props:["item"],
    data(){
        return{
            mdiStar, mdiHeartOutline
        }
    }
}
</script>