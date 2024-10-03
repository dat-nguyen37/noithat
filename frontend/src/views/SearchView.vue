<template>
    <div class="flex flex-col gap-5 p-5 md:p-10">
        <div class="flex flex-col gap-2 items-center">
            <h1 class="font-bold text-3xl">Tìm kiếm</h1>
            <p class="text-gray-600">Có <b>{{ countItem }} sản phẩm</b> cho tìm kiếm</p>
            <hr class="w-32 border-2 border-black">
        </div>
        <div class="flex flex-col gap-2">
            <p class="self-start">Kết quả tìm kiếm cho "<b>{{ searchValue }}</b>".</p>
            <div class="grid grid-cols-2 lg:grid-cols-4 gap-2">
                <ProductItem v-for="item in listSearch" :key="item.productId" :item="item"/>
            </div>
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
</template>

<script>
import ProductItem from '@/components/productItem/ProductItem.vue';
import {mdiArrowLeftThin, mdiArrowRightThin} from "@mdi/js"
import axios from 'axios';
export default {
    name:"SearchView",
    components:{ProductItem},
    data(){
        return{
            mdiArrowRightThin,mdiArrowLeftThin,
            searchValue:this.$route.query.q,
            listSearch:"",
            page:1,
            limit:12,
            countItem:0
        }
    },
    mounted(){
        this.getproduct()
    },
    watch: {
        "$route.query.q":function(newValue) {
        this.searchValue = newValue;
        this.getproduct()
        }
    },
    methods:{
        async getproduct(){
            try {
                const res=await axios.get(`https://localhost:7224/Product/search?q=${this.searchValue}&page=${this.page}&limit=${this.limit}`)
                this.listSearch=res.data.products
                this.countItem=res.data.total
            } catch (err) {
                console.log(err)
            }
        },
    }
}
</script>