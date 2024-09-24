<template>
    <div id="login-panel" class="w-full md:min-w-[23rem] flex flex-col gap-2 p-5">
            <h1 class="text-xl uppercase">{{ $t('login.header') }}</h1>
            <p class="text-gray-400">{{ $t('login.description') }}</p>
            <input type="email" :placeholder="$t('login.inputs.email_placeholder')" v-model="email" class="w-full max-w-full outline-none border p-2">
            <input type="password" :placeholder="$t('login.inputs.password_placeholder')" v-model="password" class="outline-none border p-2">
            <p v-if="message" class="text-red-500">{{ message }}</p>
            <button @click="Login" class="bg-black flex justify-center items-center gap-2 text-white font-bold py-2">
                <VueIcon v-if="$store.state.loading"  type="mdi" :path="mdiRotateRight" class="animate-spin text-white"/>
                {{ $t('login.buttons.submit') }}</button>
            <p class="text-gray-400">{{ $t('login.account_actions.new_user_prompt') }} <span @click="openRegisterPanel" class="text-blue-500 cursor-pointer">{{ $t('login.account_actions.new_user_prompt') }}</span></p>
            <p class="text-gray-400">{{ $t('login.forgot_password.prompt') }} <span @click="openRecoverPanel" class="text-blue-500 cursor-pointer">{{ $t('login.forgot_password.reset_action') }}</span></p>
    </div>
</template>

<script>
import axios from 'axios'
import {mdiRotateRight} from '@mdi/js'
export default {
    name:"LoginPanel",
    data(){
        return{
            mdiRotateRight,
            email:"",
            password:"",
            message:""
        }
    },
    methods:{
        async Login(){
            this.$store.commit('LOGIN_START')
            try {
                const res=await axios.post("https://localhost:7224/User/login",{
                    email:this.email,
                    password:this.password
                })
                this.$store.commit('LOGIN_SUCCESS',res.data.user)
                this.$route.push("/")
            } catch (err) {
                this.message=err.response.data
                this.$store.commit('LOGIN_FAILURE','')
            }
        },
        openRegisterPanel(){
            this.$emit('openRegisterPanel','register')
        },
        openRecoverPanel(){
            this.$emit('openRecoverPanel','recover')
        }
    }
}
</script>