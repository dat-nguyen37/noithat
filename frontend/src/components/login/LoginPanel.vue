<template>
    <div id="login-panel" class="w-full md:min-w-[23rem] flex flex-col gap-2 p-5">
            <h1 class="text-xl uppercase">{{ $t('login.header') }}</h1>
            <p class="text-gray-400">{{ $t('login.description') }}</p>
            <input type="email" :placeholder="$t('login.inputs.email_placeholder')" class="w-full max-w-full outline-none border p-2">
            <input type="password" :placeholder="$t('login.inputs.password_placeholder')" class="outline-none border p-2">
            <button class="bg-black text-white font-bold py-2">{{ $t('login.buttons.submit') }}</button>
            <p class="text-gray-400">{{ $t('login.account_actions.new_user_prompt') }} <a href="" class="text-blue-500">{{ $t('login.account_actions.new_user_prompt') }}</a></p>
            <p class="text-gray-400">{{ $t('login.forgot_password.prompt') }} <span @click="openRecoverPanel" class="text-blue-500 cursor-pointer">{{ $t('login.forgot_password.reset_action') }}</span></p>
    </div>
</template>

<script>
export default {
    name:"LoginPanel",
    methods:{
        openRecoverPanel(){
            this.$emit('openRecoverPanel')
        }
    }
}
</script>