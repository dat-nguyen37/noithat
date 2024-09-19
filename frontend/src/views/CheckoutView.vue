<template>
    <div class="flex flex-col">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/<p class="line-clamp-1">Thông tin giao hàng</p>
        </div>
        <div class="flex flex-col p-5 sm:p-10">
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-5">
                <div class="flex order-2 lg:order-1 flex-col gap-2">
                    <h1>Thông tin giao hàng</h1>
                    <div class="flex flex-col border p-2 relative rounded-lg">
                        <label for="name" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocused || inputValue !== '', 
                            'text-sm top-[20%] translate-y-1/3': !isFocused && inputValue === ''
                        }" 
                        class="absolute left-[10px] transition-all duration-300">
                            Họ và tên
                        </label>
                        <input id="name" type="text" class="outline-none border-b-2 focus:border-blue-500 p-2"
                                v-model="inputValue"
                                @focus="isFocused = true"
                                @blur="isFocused = inputValue !== ''">
                    </div>
                    <div class="flex flex-col border p-2 relative rounded-lg">
                        <label for="phone" :class="{
                            'text-[10px] text-green-500 top-[5px]': isFocused || inputValue !== '', 
                            'text-sm top-[20%] translate-y-1/3': !isFocused && inputValue === ''
                        }" 
                        class="absolute left-[10px] transition-all duration-300">
                            Số điện thoại
                        </label>
                        <input id="phone" type="text" class="outline-none border-b-2 focus:border-blue-500 p-2"
                                v-model="inputValue"
                                @focus="isFocused = true"
                                @blur="isFocused = inputValue !== ''">
                    </div>
                    <div class="grid lg:grid-cols-3 gap-2">
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': inputValue !== '', 
                                'text-sm top-[20%] translate-y-1/3 hidden': inputValue === ''
                            }" 
                            class="absolute left-[10px] transition-all duration-300">
                                Tỉnh/ thành
                            </label>
                            <select name="" id="" class="outline-none text-sm border-b-2 focus:border-blue-500 p-2"
                                    v-model="inputValue"
                                    @blur="inputValue !== ''">
                                <option value="">Chọn tỉnh/ thành</option>
                                <option value="dss">dsds</option>
                            </select>
                        </div>
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': inputValue !== '', 
                                'text-sm top-[20%] translate-y-1/3 hidden': inputValue === ''
                            }" 
                            class="absolute left-[10px] transition-all duration-300">
                                Tỉnh/ thành
                            </label>
                            <select name="" id="" class="outline-none border-b-2 text-sm focus:border-blue-500 p-2"
                                    v-model="inputValue"
                                    @blur="inputValue !== ''">
                                <option value="">Chọn tỉnh/ thành</option>
                                <option value="dss">dsds</option>
                            </select>
                        </div>
                        <div class=" flex flex-col border p-2 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-[5px]': inputValue !== '', 
                                'text-sm top-[20%] translate-y-1/3 hidden': inputValue === ''
                            }" 
                            class="absolute left-[10px] transition-all duration-300">
                                Tỉnh/ thành
                            </label>
                            <select name="" id="" class="outline-none text-sm border-b-2 focus:border-blue-500 p-2"
                                    v-model="inputValue"
                                    @blur="inputValue !== ''">
                                <option value="">Chọn tỉnh/ thành</option>
                                <option value="dss">dsds</option>
                            </select>
                        </div>
                    </div>
                    <div class="border p-2 relative rounded-lg">
                            <label for="description" :class="{
                                'text-[10px] text-green-500 top-[5px]': isFocused || inputValue !== '', 
                                'text-sm top-[20%] translate-y-1/4': !isFocused && inputValue == ''
                            }" 
                            class="absolute left-[10px] transition-all duration-300">
                                Viết gì đó ...
                            </label>
                            <textarea id="description" class="w-full outline-none border-b-2 focus:border-blue-500 p-2"
                                v-model="inputValue"
                                @focus="isFocused = true"
                                @blur="isFocused = inputValue !== ''"/>
                        </div>
                    <div class="flex flex-col gap-2">
                        <h1 class="sm:text-xl">Phương thức thanh toán</h1>
                        <div class="border flex flex-col text-xs sm:text-sm text-gray-500">
                            <div class="flex items-center gap-2 border-b p-4">
                                <input type="radio" name="" id="" class="w-5 h-5">
                                <label for="" class="flex items-center gap-2">
                                    <img src="https://hstatic.net/0/0/global/design/seller/image/payment/cod.svg?v=6" width="40" height="40" alt="">
                                    Thanh toán tiền mặt khi giao hàng (COD)</label>
                            </div>
                            <div class="flex items-center gap-2 border-b p-4">
                                <input type="radio" name="" id="" class="w-5 h-5">
                                <label for="" class="flex items-center gap-2">
                                    <img src="https://hstatic.net/0/0/global/design/seller/image/payment/vnpay_new.svg?v=6" width="40" height="40" alt="">
                                    Thanh toán online qua cổng VNPay (ATM/Visa/MasterCard/JCB/QR Pay trên Internet Banking)</label>
                            </div>
                        </div>
                    </div>
                    <div class="flex flex-col gap-2 md:flex-row justify-between items-center">
                        <a href="/cart" class=" text-blue-700">Giỏ hàng</a>
                        <div class="w-full md:w-40 text-center p-2 text-white bg-blue-700 rounded-lg cursor-pointer">Hoàn tất đơn hàng</div>
                    </div>
                </div>
                <div class="order-1 lg:order-2 bg-gray-100 p-5">
                    <div @click="orderSumary=!orderSumary" class=" flex lg:hidden justify-between cursor-pointer border-b border-black py-2">
                        <div class="text-blue-500 flex items-center gap-2">
                            <VueIcon type="mdi" :path="mdiCartOutline"/>
                            <p class="text-sm">Hiển thị thông tin đơn hàng</p>
                            <VueIcon type="mdi" :path="mdiChevronDown"/>
                        </div>
                        <p class="">11,890,000₫</p>
                    </div>
                    <div v-if="orderSumary" class="w-full py-4 border-b border-black">
                        <div class="flex gap-2">
                            <div class="relative w-12 h-12 sm:w-20 sm:h-20 border-2 rounded-lg">
                                <img src="/assets/image/New/new1.webp" alt="" class="w-full h-full rounded-lg">
                                <span class="absolute -top-2 -right-2 w-5 h-5 rounded-full bg-gray-500 flex justify-center items-center text-white">1</span>
                            </div>
                            <div class="flex flex-col gap-2 text-gray-500 self-center">
                                <p class="text-xs sm:text-sm">Hệ tủ bếp MOHO Kitchen Premium Ubeda Nhiều Kích Thước</p>
                                <p class="text-xs sm:text-sm">1m5</p>
                            </div>
                            <p class="self-center text-xs sm:text-sm">11,890,000₫</p>
                        </div>
                    </div>
                    <div class="flex gap-3 py-4 border-b border-black">
                        <div class="flex flex-col w-2/3 relative rounded-lg">
                            <label :class="{
                                'text-[10px] text-green-500 top-0 ': inputValue !== '', 
                                'text-sm top-[10%] translate-y-1/3 hidden': inputValue === ''
                                }" 
                                class="absolute left-[10px] transition-all duration-500">
                                Mã giảm giá
                            </label>
                            <input type="text" placeholder="Mã giảm giá" class="outline-none focus:border-blue-500 p-2"
                                    v-model="inputValue"
                                    @focus="isFocused = true"
                                    @blur="isFocused = inputValue !== ''">
                        </div>
                        <button class="text-white bg-gray-500 rounded-lg p-2 text-sm">Sử dụng</button>
                    </div>
                    <div v-if="orderSumary" class="flex flex-col py-4">
                        <div class="flex justify-between text-gray-500 border-black">
                            <p>Tạm tính</p>
                            <p>11,890,000₫</p>
                        </div>
                        <div class="flex justify-between text-gray-500">
                            <p>Phí vận chuyển</p>
                            <p>- 1,000,000₫</p>
                        </div>
                        <div class="flex justify-between text-gray-500 pb-2">
                            <p>Ưu đãi</p>
                            <p>- 1,000,000₫</p>
                        </div>
                        <div class="flex justify-between text-gray-500 pt-2 border-t border-black">
                            <p class="text-black">Tổng cộng</p>
                            <p class="text-xl"> 10,890,000₫</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {mdiCartOutline, mdiChevronDown} from '@mdi/js'
export default {
    name:"CheckoutView",
    data() {
        return {
            mdiCartOutline,mdiChevronDown,
            isFocused: false,
            inputValue: '',
            orderSumary:false
        }
    }
}
</script>

<style>

</style>