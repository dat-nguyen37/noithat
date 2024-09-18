<template>
    <nav class="flex flex-col">
        <div class="bg-blue-800 text-sm py-1 px-5 text-center text-white">Nội Thất MOHO miễn phí giao hàng & lắp đặt tại TP.HCM, Hà Nội, Biên Hòa và một số khu vực tại Bình Dương</div>
        <div class="h-16 flex justify-between px-5 md:px-0 md:justify-around items-center gap-2">
            <div @click="openMenu" class="flex md:hidden relative items-center cursor-pointer">
                <VueIcon type="mdi" :path="!menu ? mdiViewHeadline : mdiClose  " size="40"/>
                <ul id="menu" :class="menu ? 'flex':'hidden'" class="absolute flex-col font-bold bg-white w-[calc(100vw-17px)] z-10 top-14 -left-5 shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                    <li @click.stop="openMenuChild" class="flex flex-col border-b">
                        <a href="javascript:void(0)" class="flex p-2 hover:bg-gray-200">BST Bắc Âu
                            <VueIcon type="mdi" :path="!menuChild ? mdiChevronDown : mdiChevronUp" size="20"/>
                        </a>
                        <div :class="menuChild ? 'flex' : 'hidden'" class=" px-4">
                            <ul class="flex flex-col">
                                <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                                <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                                <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                                <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                            </ul>
                        </div>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="" class="flex">Tủ Bếp </a>
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="" class="flex">Khuyến Mãi </a>
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </li>
                    <li class="flex items-center p-2 hover:bg-gray-200 hover:text-red-500 border-b"><a href="" class="flex">Dịch Vụ </a>
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </li>
                </ul>
            </div>
            <div class="col-span-4 justify-center">
                <img src="/assets/image/logo.png" alt="" class=" w-40 h-8">
            </div>
            <div class="w-80 hidden md:flex">
                <div class="flex items-center relative border-2 p-1 border-gray-100 w-80 h-10">
                    <input type="text" placeholder="Tìm kiếm sản phẩm..." class="outline-none w-2/3">
                    <button class="absolute right-0 bg-gray-700 h-10 w-10 flex justify-center items-center">
                        <VueIcon type="mdi" :path="mdiMagnify" class="text-white"/>
                    </button>
                </div>
            </div>
            <div class="flex items-center gap-5">
                <div class=" flex justify-center items-center gap-2 relative">
                    <a @click="openLogin">
                        <VueIcon type="mdi" :path="mdiAccountOutline " class="self-center cursor-pointer" size="30"/>
                    </a>
                    <div @click="openLogin" class="hidden lg:flex flex-col cursor-pointer">
                        <p class="text-sm text-gray-500">{{ $t('login.buttons.submit') }} / {{ $t('register.buttons.submit') }}</p>
                        <p class="flex text-sm font-medium">{{ $t('acount.header') }} <VueIcon type="mdi" :path="mdiChevronDown " size="20"/></p>
                    </div>
                    <div id="login" :class="login ?'flex':'hidden'" class="absolute top-14 text-sm w-screen -right-[120px] md:w-[24rem] md:-right-20 z-20 bg-white text-center shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <div class="overflow-hidden">
                            <div class="flex w-[100%] transform transition-transform duration-500 ease-out" :style="{ transform: recoverPanel ? 'translateX(-100%)' : 'translateX(0)' }">
                                <div id="login-panel" class="min-w-full md:min-w-[24rem] flex flex-col gap-2 p-2">
                                    <h1 class="text-xl uppercase">{{ $t('login.header') }}</h1>
                                    <p class="text-gray-400">{{ $t('login.description') }}</p>
                                    <input type="email" :placeholder="$t('login.inputs.email_placeholder')" class="outline-none border p-2">
                                    <input type="password" :placeholder="$t('login.inputs.password_placeholder')" class="outline-none border p-2">
                                    <button class="bg-black text-white font-bold py-2">{{ $t('login.buttons.submit') }}</button>
                                    <p class="text-gray-400">{{ $t('login.account_actions.new_user_prompt') }} <a href="" class="text-blue-500">{{ $t('login.account_actions.new_user_prompt') }}</a></p>
                                    <p class="text-gray-400">{{ $t('login.forgot_password.prompt') }} <span @click="openRecoverPanel" class="text-blue-500 cursor-pointer">{{ $t('login.forgot_password.reset_action') }}</span></p>
                                </div>
                                <div id="recover-panel" class="min-w-full md:min-w-[24rem] flex flex-col gap-2 p-2">
                                    <h1 class="text-xl uppercase">{{ $t('recover.headerr') }}</h1>
                                    <div class="flex gap-2">
                                        <input type="radio" id="emailCheck" @change="changeRecoverLogin" :checked="recoverLogin==='email'&& 'email'" value="email" name="recoverLogin" class="">
                                        <label for="emailCheck">{{ $t('recover.email_option') }}</label>
                                    </div>
                                    <div class="flex gap-2">
                                        <input type="radio" id="phoneCheck" @change="changeRecoverLogin" :checked="recoverLogin==='phone'&& 'phone'" value="phone" name="recoverLogin" class="">
                                        <label for="phoneCheck">{{ $t('recover.phone_option') }}</label>
                                    </div>
                                    <div v-if="recoverLogin==='email'" class="flex flex-col gap-2">
                                        <input type="email" :placeholder="$t('recover.inputs.email_placeholder')" class="outline-none border p-2">
                                        <button class="bg-black text-white font-bold py-2">{{ $t('recover.buttons.recover') }}</button>
                                        <p class="text-gray-400">{{ $t('recover.return_to_login') }} <span @click="openRecoverPanel" class="text-blue-500 cursor-pointer">{{ $t('recover.back_to_login') }}</span></p>
                                    </div>
                                    <div v-if="recoverLogin==='phone'" class="flex flex-col gap-2">
                                        <input type="phone" :placeholder="$t('recover.inputs.phone_placeholder')" class="outline-none border p-2">
                                        <button class="bg-black text-white font-bold py-2">{{ $t('recover.buttons.send_code') }}</button>
                                    </div>
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
                            <div class="hidden flex-col">
                                <div class="flex py-2 border-b">
                                    <img src="" alt="" class="w-16 h-16 object-cover">
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
                            <div class="flex flex-col items-center py-2 border-b">
                                <VueIcon type="mdi" :path="mdiShoppingOutline" size="50" class="self-center"/>
                                <p>{{ $t('cart.description') }}</p>
                            </div>
                        </div>
                        <div class="py-2 flex flex-col gap-2">
                            <div class="flex justify-between">
                                <p class="uppercase">{{ $t('cart.total_Amount') }}:</p>
                                <p class="text-red-500 font-bold">0 <u>đ</u></p>
                            </div>
                            <div class="flex gap-2 justify-between text-white text-sm uppercase">
                                <a href="/cart" class="w-1/2 bg-gray-600 py-2">{{ $t('cart.buttons.show_cart') }}</a>
                                <a href="" class="w-1/2 bg-blue-800 py-2">{{ $t('cart.buttons.payment') }}</a>
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
                <button class="absolute right-0 bg-gray-700 h-10 w-10 flex justify-center items-center">
                    <VueIcon type="mdi" :path="mdiMagnify" class="text-white"/>
                </button>
            </div>
            <ul class="hidden md:flex gap-5 px-10 text-sm">
                <li class="flex items-center py-4 relative group">
                    <a href="" class="flex">BST Bắc Âu
                        <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                    </a>
                    <ul class="hidden absolute group-hover:flex w-32 flex-col top-12 bg-white shadow-[0px_0px_2px_2px_rgba(0,0,0,0.3)]">
                        <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                        <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                        <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                        <li class="hover:bg-gray-300 hover:text-red-500 border-b"><a href="" class="flex p-2">Bộ sưu tập</a></li>
                    </ul>
                </li>
                <li class="flex items-center"><a href="">Tủ Bếp </a>
                    <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                </li>
                <li class="flex items-center"><a href="">Khuyến Mãi </a>
                    <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                </li>
                <li class="flex items-center"><a href="">Dịch Vụ </a>
                    <VueIcon type="mdi" :path="mdiChevronDown " size="20"/>
                </li>
            </ul>
        </div>
    </nav>
</template>

<script>
import {mdiMagnify,mdiAccountOutline ,mdiChevronDown,mdiTrashCanOutline ,mdiShoppingOutline,mdiChevronRight ,mdiHeart,mdiViewHeadline,mdiChevronUp,mdiClose      } from '@mdi/js'
export default {
    name:"NavBar",
    data() {
        return {
            menu:false,
            menuChild:false,
            login:false,
            cart:false,
            recoverLogin:'email',
            loinPanel:true,
            recoverPanel:false,
            mdiMagnify ,
            mdiAccountOutline,
            mdiChevronDown ,
            mdiShoppingOutline,mdiHeart,mdiViewHeadline,mdiChevronUp,mdiClose ,mdiChevronRight,mdiTrashCanOutline
        };
  },
  methods:{
    openMenu(){
        this.menu=!this.menu
        this.login=false
        this.cart=false
        if (!this.menu) {
        this.menuChild = false;
      }
    },
    openMenuChild(){
        this.menuChild=!this.menuChild
    },
    openLogin(){
        this.login=!this.login
        this.cart=false
        this.menu=false
    },
    changeRecoverLogin(e){
        this.recoverLogin=e.target.value
    },
    openRecoverPanel(){
        this.recoverPanel=!this.recoverPanel
        this.loginPanel=!this.loginPanel
    },
    openCart(){
        this.cart=!this.cart
        this.login=false
        this.menu=false
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