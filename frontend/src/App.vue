<template>
  <div id="app" class="flex flex-col min-h-screen">
    <NavBar/>
    <router-view/>
    <div @click="openSetting" class="fixed z-50 right-5 bottom-10 w-10 h-10 rounded-full bg-yellow-500 flex justify-center items-center cursor-pointer">
      <VueIcon type="mdi" :path="mdiCog " class="animate-spin"/>
      <div @click="scrollToTop()" :class="isSetting ? 'translate-y-0 opacity-100 duration-700' : 'translate-y-10 opacity-0 duration-100'" class="absolute transition-all -top-12 z-40">
        <VueIcon type="mdi" :path="mdiArrowUpBold" size="25" class="text-blue-500 w-8 h-8 rounded-full hover:bg-gray-700 flex justify-center items-center"/>
      </div>
      <div @click="toggleLanguage" :class="isSetting ? 'translate-x-0 opacity-100 duration-300' : 'translate-x-10 translate-y-10 opacity-0 duration-300'" class="z-30 absolute transition-all -left-12 -top-8 w-8 h-8 rounded-full bg-yellow-400 text-sm font-bold flex justify-center items-center">
        <p>{{ this.$i18n.locale ==='vn' ?'en' :'vn' }}</p>
      </div>
      <div :class="isSetting ? 'translate-x-0 opacity-100 duration-100 ease-in' : 'translate-x-10  opacity-0 duration-700'" class="z-20 absolute transition-all -left-14 top-5 w-8 h-8 rounded-full hover:bg-gray-700 hover:text-white flex justify-center items-center">
        <a href="/"><VueIcon type="mdi" :path="mdiHome" size="25"/></a>
      </div>
    </div>
    <Footer/>
  </div>
</template>

<script>
import NavBar from './components/navbar/NavBar.vue'
import Footer from './components/footer/Footer.vue'
import {mdiCog,mdiArrowUpBold,mdiHome } from "@mdi/js"
export default {
  components:{
    NavBar,
    Footer
  },
  data(){
    return{
      mdiCog,mdiArrowUpBold,mdiHome,
      isSetting:false,
    }
  },
  methods:{
    scrollToTop(){
      window.scrollTo({top:0,behavior:"smooth"})
    },
    openSetting(){
      this.isSetting=!this.isSetting
    },
    toggleLanguage() {
      if(this.$i18n.locale=='vn'){
        this.$i18n.locale='en'
      }else{
        this.$i18n.locale='vn'
      }
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>
