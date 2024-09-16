<template>
    <div class="relative flex flex-col gap-2 border">
        <img src="/assets/image/New/new1.webp" alt="" class="">
        <div class="px-2">
            <p class="uppercase text-sm font-semibold">Giường Ngủ Gỗ Tràm MOHO HOBRO 301</p>
            <p class="text-red-500">8,992,500<u>đ</u>&nbsp;<s class="text-gray-400">11,990,000<u>đ</u></s></p>
            <div class="flex justify-between">
                <div class="flex">
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <VueIcon type="mdi" :path="mdiStar" size="20"/>
                    <p>(27)</p>
                </div>
                <div class="flex flex-col">
                    <p>Đã bán 226</p>
                    <VueIcon type="mdi" :path="mdiHeartOutline" class="self-end"/>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiStar, mdiHeartOutline} from '@mdi/js'

export default {
    name:"ProductItem",
    data(){
        return{
            mdiStar, mdiHeartOutline
        }
    }
}
</script>