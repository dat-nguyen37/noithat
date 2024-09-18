<template>
     <div class="flex flex-col">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/<p class="line-clamp-1">Giỏ hàng (1)</p>
        </div>
        <div class="flex flex-col gap-5 p-5 md:p-10">
            <h1 class="text-center font-bold text-base md:text-3xl"><u>Giỏ hàng của bạn</u></h1>
            <div class="flex flex-col md:grid grid-cols-12 gap-5">
                <div class="col-span-8">
                    <div class="bg-gray-100 p-2">Có <b>1 sản phẩm</b> trong giỏ hàng</div>
                    <div class="flex flex-col mt-5">
                        <table class="w-full border table">
                            <thead class="w-full text-gray-600 border">
                                <tr class="w-full hidden lg:table-row text-xs lg:text-base font-bold">
                                    <th class="p-2 text-left">THÔNG TIN SẢN PHẨM</th>
                                    <th class="p-2 text-left">ĐƠN GIÁ</th>
                                    <th class="p-2 text-left">SỐ LƯỢNG</th>
                                    <th class="p-2 text-left">THÀNH TIỀN</th>
                                </tr>
                            </thead>
                            <tbody>
                                <CartItem v-for="item in 2" :key="item"/>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-span-4"></div>
            </div>
        </div>
     </div>
</template>

<script>
import CartItem from '@/components/cartItem/CartItem.vue';
export default {
    name:"CartView",
    components:{CartItem}
}
</script>