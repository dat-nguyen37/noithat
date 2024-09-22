<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/ <p>Trang khách hàng</p>
        </div>
        <div class="p-5">
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