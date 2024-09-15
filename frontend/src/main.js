import Vue from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import router from './router'
import VueIcon from '@jamescoyle/vue-icon';

Vue.config.productionTip = false
Vue.component('VueIcon', VueIcon);
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
