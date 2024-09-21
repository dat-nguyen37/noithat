<template>
    <div id="register-panel" class="w-full md:min-w-[23rem] flex flex-col gap-2 p-5">
            <h1 class="text-xl uppercase">{{ $t('recover.header') }}</h1>
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
</template>

<script>
export default {
    name:"RecoverPanel",
    data(){
        return{
            recoverLogin:'email',
        }
    },
    methods:{
        changeRecoverLogin(e){
            this.recoverLogin=e.target.value
        },
        openRecoverPanel(){
            this.$emit('openRecoverPanel')
        }
    }
}
</script>