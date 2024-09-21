<template>
    <div id="register-panel" class="w-full md:min-w-[23rem] flex flex-col gap-5 p-5">
            <h1 class="text-xl uppercase">{{ $t('login.header') }}</h1>
            <input type="text" placeholder="Nhập email đăng kí" class="p-2 outline-none border">
            <p class="text-gray-400">{{ $t('recover.return_to_login') }} <span @click="openLoginPanel" class="text-blue-500 cursor-pointer">{{ $t('recover.back_to_login') }}</span></p>
            <button class="w-full p-2 text-white bg-black">Xác nhận</button>
    </div>
</template>

<script>
export default {
    name:"RegisterPanel",
    data(){
        return{
        }
    },
    methods:{
        openLoginPanel(){
            this.$emit('openLoginPanel','login')
        }
    }
}
</script>