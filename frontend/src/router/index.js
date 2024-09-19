import CartView from '@/views/CartView.vue'
import CheckoutView from '@/views/CheckoutView.vue'
import DepartmentView from '@/views/DepartmentView.vue'
import HomeView from '@/views/HomeView.vue'
import ProductDetail from '@/views/ProductDetail.vue'
import SearchView from '@/views/SearchView.vue'
import Vue from 'vue'
import VueRouter from 'vue-router'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/product/:id',
    name: 'productdetail',
    component: ProductDetail
  },
  {
    path: '/cart',
    name: 'cart',
    component: CartView
  },
  {
    path: '/search',
    name: 'search',
    component: SearchView
  },
  {
    path: '/category/:id',
    name: 'category',
    component: DepartmentView
  },
  {
    path: '/checkout',
    name: 'checkout',
    component: CheckoutView
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
