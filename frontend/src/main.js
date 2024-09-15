import Vue from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import router from './router'
import VueIcon from '@jamescoyle/vue-icon';
import VueI18n from 'vue-i18n'
import vnMessage from './lang/vn.json'
import enMessage from './lang/en.json'

Vue.config.productionTip = false
Vue.component('VueIcon', VueIcon);
Vue.use(VueI18n)
const messages = {
  vn: vnMessage,
  en: enMessage,
}
const i18n = new VueI18n({
  locale: 'vn', 
  messages,
  fallbackLocale: 'vn',
})
new Vue({
  router,
  i18n,
  render: h => h(App)
}).$mount('#app')
