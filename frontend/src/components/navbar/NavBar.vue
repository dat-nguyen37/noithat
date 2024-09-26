<template>
    <nav class="flex flex-col border-b">
        <div class="bg-blue-800 text-sm py-1 px-5 text-center text-white">Nội Thất MOHO miễn phí giao hàng & lắp đặt tại TP.HCM, Hà Nội, Biên Hòa và một số khu vực tại Bình Dương</div>
        <div class="h-16 flex justify-between px-5 md:px-0 md:justify-around items-center gap-2">
            <div @click="openMenu" class="flex lg:hidden relative items-center cursor-pointer">
                <VueIcon type="mdi" :path="!menu ? mdiViewHeadline : mdiClose  " size="40"/>
                <ul id="menu" :class="menu ? 'flex':'hidden'" class="absolute  flex-col font-bold bg-white w-[50vw] z-10 top-14 -left-5 shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                    <li v-for="(item, index) in category" :key="item.categoryTypeId" class="flex flex-col">
                        <a href="javascript:void(0)" class="flex p-2 hover:bg-gray-200" @click.stop="toggleMenu(index)">
                            {{ item.name }}
                            <VueIcon type="mdi" :path="isMenuOpen(index) ? mdiChevronUp : mdiChevronDown" size="20" />
                        </a>
                        <div :class="isMenuOpen(index) ? 'flex' : 'hidden'" class="px-4">
                            <ul class="flex flex-col">
                                <li v-for="childItem in item.categories" :key="childItem.categoryId" class="hover:bg-gray-300 hover:text-red-500 border-b">
                                <router-link :to="{ name: 'category', params: { id: childItem.categoryId } }" class="flex p-2" >
                                    {{ childItem.name }}
                                </router-link>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="" class="flex">Khuyến Mãi </a>
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="" class="flex">Dịch Vụ </a>
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="/pages/about" class="flex">Về chúng tôi </a></li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="/pages/contact" class="flex">Liên hệ </a></li>
                </ul>
            </div>
            <div class="col-span-4 justify-center">
                <img src="/assets/image/logo.png" alt="" class=" w-40 h-8">
            </div>
            <div class="w-80 hidden md:flex">
                <div class="flex items-center relative border-2 p-1 border-gray-100 w-80 h-10">
                    <input type="text" placeholder="Tìm kiếm sản phẩm..." class="outline-none w-2/3">
                    <a href="/search?q=njdf" class="absolute right-0 bg-gray-700 h-10 w-10 flex justify-center items-center">
                        <VueIcon type="mdi" :path="mdiMagnify" class="text-white"/>
                    </a>
                </div>
            </div>
            <div class="flex items-center gap-5">
                <div class=" flex justify-center items-center gap-2 relative">
                    <a @click="openLogin">
                        <VueIcon type="mdi" :path="mdiAccountOutline " class="self-center cursor-pointer" size="30"/>
                    </a>
                    <div  @click="openLogin" class="hidden lg:flex flex-col cursor-pointer">
                        <div v-if="!$store.state.user">
                            <p class="text-sm text-gray-500">{{ $t('login.buttons.submit') }} / {{ $t('register.buttons.submit') }}</p>
                            <p class="flex text-sm font-medium">{{ $t('acount.header') }} <VueIcon type="mdi" :path="mdiChevronDown " size="20"/></p>
                        </div>
                        <div v-else>
                            <p class="text-sm text-gray-500">{{ $t('acount.header') }}</p>
                            <p class="flex text-sm font-medium">{{ $store.state.user.email }} <VueIcon type="mdi" :path="mdiChevronDown " size="20"/></p>
                        </div>
                    </div>
                    <div v-if="$store.state.user" :class="login ?'flex':'hidden'" class="absolute top-14 text-sm z-20 w-20 bg-white text-center shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <ul class="">
                            <li class="border-b p-2"><a href="/profile">Profile</a></li>
                            <li @click="logout" class="border-b p-2">Logout</li>
                        </ul>
                    </div>
                    <div v-else id="login" :class="login ?'flex':'hidden'" class="absolute top-14 text-sm w-screen -right-[120px] md:w-[23rem] md:-right-20 z-20 bg-white text-center shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <div class="overflow-hidden w-full">
                            <div class="flex w-[300%] transform transition-transform duration-500 ease-out" 
                                :style="{ transform: recoverPanel === 'login' ? 'translateX(-33.33%)' : 
                                recoverPanel === 'register' ? 'translateX(0%)' : 
                                'translateX(-66.66%)' }">
                                <div class="w-[100vw]">
                                    <RegisterPanel @openLoginPanel="openLoginPanel"/>
                                </div>
                                <div class="w-[100vw]">
                                    <LoginPanel @openRecoverPanel="openRecoverPanel" @openRegisterPanel="openRegisterPanel"/>
                                </div>
                                <div class="w-[100vw]">
                                    <RecoverPanel @openLoginPanel="openLoginPanel"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=" flex items-center justify-center gap-1 relative">
                    <div @click="openCart" class="relative cursor-pointer">
                        <a href="javascript:void(0)"><VueIcon type="mdi" :path="mdiShoppingOutline " size="30"/></a>
                        <span class="absolute top-0 right-0 flex justify-center items-center w-4 h-4 rounded-full bg-orange-600 text-white">0</span>
                    </div>
                    <p @click="openCart" class="hidden lg:flex cursor-pointer">{{ $t('cart.header') }}</p>
                    <div id="cart" :class="cart ?'flex':'hidden'" class="absolute flex-col  top-14 p-2 text-sm w-screen -right-[70px] md:w-[24rem] md:-right-20 z-20 bg-white text-center shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <p class="uppercase font-bold text-gray-500 py-2 border-b w-full">{{ $t('cart.header') }}</p>
                        <div>
                            <div class=" flex-col gap-2">
                                <div class="flex gap-2 p-4 border-b">
                                    <img src="/assets/image/New/new1.webp" alt="" class="w-16 h-16 object-cover">
                                    <div class="flex flex-col justify-between">
                                        <p class="text-sm">Giường Ngủ Gỗ MOHO VLINE 601 Nhiều Kích Thước</p>
                                        <div class="flex items-center justify-around">
                                            <p class="h-5 w-5 bg-gray-300">1</p>
                                            <p class="font-bold">5,990,000 <s class="font-light">8,990,000</s></p>
                                            <button><VueIcon type="mdi" :path="mdiTrashCanOutline" class="text-red-500"/></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="hidden flex-col items-center py-2 border-b">
                                <VueIcon type="mdi" :path="mdiShoppingOutline" size="50" class="self-center"/>
                                <p>{{ $t('cart.description') }}</p>
                            </div>
                        </div>
                        <div class="p-4 flex flex-col gap-2">
                            <div class="flex justify-between">
                                <p class="uppercase">{{ $t('cart.total_Amount') }}:</p>
                                <p class="text-red-500 font-bold">0 <u>đ</u></p>
                            </div>
                            <div class="flex gap-2 justify-between text-white text-sm uppercase">
                                <a href="/cart" class="w-1/2 bg-gray-600 py-2">{{ $t('cart.buttons.show_cart') }}</a>
                                <a href="/checkout" class="w-1/2 bg-blue-800 py-2">{{ $t('cart.buttons.payment') }}</a>
                            </div>
                        </div>

                    </div>
                </div>
                <div class=" flex ">
                    <div class="relative">
                        <VueIcon type="mdi" :path="mdiHeart " class="text-red-500" size="30"/>
                        <span class="absolute top-0 right-0 flex justify-center items-center w-4 h-4 rounded-full bg-black text-white">0</span>
                    </div>
                </div>
            </div>
        </div>
        <div class="w-full p-2">
            <div class="flex md:hidden items-center relative border-2 border-gray-100 w-full h-10">
                <input type="text" placeholder="Tìm kiếm sản phẩm..." class="outline-none w-1/2">
                <a href="/search?q=sds" class="absolute right-0 bg-gray-700 h-10 w-10 flex justify-center items-center">
                    <VueIcon type="mdi" :path="mdiMagnify" class="text-white"/>
                </a>
            </div>
            <ul class="hidden lg:flex gap-5 px-10 text-sm">
                <li v-for="items in category" :key="items.categoryTypeId" class="flex items-center py-4 relative group">
                    <a href="javascript:void(0)" class="flex">{{ items.name }}
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </a>
                    <ul class="hidden absolute group-hover:flex w-32 flex-col z-50 top-12 bg-white shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <li v-for="item in items.categories" :key="item.categoryId" class="hover:bg-gray-300 hover:text-red-500 border-b">
                            <router-link :to="{name:'category',params:{id:item.categoryId}}" class="flex p-2">{{item.name}}</router-link>
                        </li>
                    </ul>
                </li>
                <li class="flex items-center"><a href="">Khuyến Mãi </a>
                    <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                </li>
                <li class="flex items-center"><a href="/pages/about">Dịch Vụ </a>
                    <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                </li>
                <li class="flex items-center"><a href="/pages/about">Về chúng tôi </a></li>
                <li class="flex items-center"><a href="/pages/contact">Liên hệ </a></li>
            </ul>
        </div>
    </nav>
</template>

<script>
import {mdiMagnify,mdiAccountOutline ,mdiChevronDown,mdiTrashCanOutline ,mdiShoppingOutline,mdiChevronRight ,mdiHeart,mdiViewHeadline,mdiChevronUp,mdiClose      } from '@mdi/js'
import RecoverPanel from '../recover/RecoverPanel.vue';
import LoginPanel from '../login/LoginPanel.vue';
import RegisterPanel from '../register/RegisterPanel.vue';
import axios from 'axios'
export default {
    name:"NavBar",
    components:{RecoverPanel,LoginPanel,RegisterPanel},
    data() {
        return {
            menu:false,
            openMenuIndexes: [],
            login:false,
            cart:false,
            loinPanel:true, 
            recoverPanel:'login',
            category:"",
            mdiMagnify ,
            mdiAccountOutline,
            mdiChevronDown ,
            mdiShoppingOutline,mdiHeart,mdiViewHeadline,mdiChevronUp,mdiClose ,mdiChevronRight,mdiTrashCanOutline,
        };
  },
  mounted(){
        this.getCategory()
    },
  methods:{
    openMenu(){
        this.menu=!this.menu
        this.login=false
        this.cart=false
    },
    toggleMenu(index) {
      const menuIndex = this.openMenuIndexes.indexOf(index);
      if (menuIndex > -1) {
        // Nếu menu đã mở, đóng nó
        this.openMenuIndexes.splice(menuIndex, 1);
      } else {
        // Nếu menu chưa mở, mở nó
        this.openMenuIndexes.push(index);
      }
    },
    isMenuOpen(index) {
      // Kiểm tra xem menu có đang mở hay không
      return this.openMenuIndexes.includes(index);
    },
    openLogin(){
        this.login=!this.login
        this.cart=false
        this.menu=false
    },
    openLoginPanel(data){
        this.recoverPanel=data
    },
    openRegisterPanel(data){
        this.recoverPanel=data
    },
    openRecoverPanel(data){
        this.recoverPanel=data
    },
    openCart(){
        this.cart=!this.cart
        this.login=false
        this.menu=false
    },
    logout(){
        this.$store.commit('LOGOUT')
    },
    async getCategory(){
            try {
                const res=await axios.get("https://localhost:7224/CategoryType/getAll")
                this.category=res.data
            } catch (err) {
                console.log(err)
            }
        }
  }
}
</script>

<style lang="css">
#menu::before {
  content: "";
  width: 0;
  height: 0;
  position: absolute;
  top: -20px;
  left: 30px;
  border-left: 10px solid transparent;
  border-right: 10px solid transparent;
  border-bottom: 20px solid white;
  display: inline-block;
  filter: drop-shadow(0px -2px rgba(0,0,0,0.3));
}
#login::before, #cart::before{
  content: "";
  width: 0;
  height: 0;
  position: absolute;
  top: -14px;
  right: 100px;
  border-left: 10px solid transparent;
  border-right: 10px solid transparent;
  border-bottom: 15px solid white;
  display: inline-block;
  filter: drop-shadow(0px -2px rgba(0,0,0,0.3));
}
</style>