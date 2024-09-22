<template>
    <div class="w-full">
        <div class="flex w-full bg-gray-100 h-14 px-5 ">
            <ul class="flex items-center gap-3 text-sm text-gray-500">
                <li><a href="/" class="hover:text-yellow-600">Trang chủ </a></li>
                <li><a href="" class="hover:text-yellow-600">
                    <VueIcon type="mdi" :path="mdiChevronDown"/>
                    Trang khách hàng
                </a></li>
            </ul>
        </div>
        <div class="p-10">
            <div class="flex flex-col md:grid grid-cols-12 gap-5">
                <div class="col-span-3 md:col-span-4">
                    <div @click="showMenu" class="flex items-center justify-between bg-black text-white text-center p-2">
                        <div>
                            <h1 class="text-xl">Trang tài khoản</h1>
                            <strong class="text-sm">Xin chào, <span class="text-yellow-600">datnguyen</span> !</strong>
                        </div>
                        <VueIcon type="mdi" :path="menu ? 'mdiChevronUp' : 'mdiChevronDown'" />
                    </div>
                    <ul v-if="menu" class="py-2 text-sm bg-gray-100">
                        <li><a href="/profile" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Thông tin tài khoản</a></li>
                        <li><a href="/profile/orders" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Đơn hàng của bạn</a></li>
                        <li><a href="/profile/changePass" class="flex hover:text-yellow-600 hover:bg-gray-700 p-2">Đổi mật khẩu</a></li>
                    </ul>
                </div>
                <div class="col-span-9 md:col-span-8">
                    <router-view></router-view>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { mdiChevronDown,mdiChevronUp,mdiArrowRight,mdiArrowLeft } from '@mdi/js';

export default {
    name:"ProfileView",
    data(){
        return{
            menu:true,
            mdiChevronDown,mdiArrowRight,mdiArrowLeft,mdiChevronUp
        }
    },
    methods:{
        showMenu(){
           this.menu=!this.menu 
        }
    }
}
</script>