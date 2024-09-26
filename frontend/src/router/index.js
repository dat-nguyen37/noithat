import Acount from '@/components/acount/Acount.vue'
import ChangePass from '@/components/changepass/ChangePass.vue'
import OrderView from '@/components/order/OrderView.vue'
import OrderDetail from '@/components/orderDetail/OrderDetail.vue'
import AboutView from '@/views/AboutView.vue'
import CartView from '@/views/CartView.vue'
import CheckoutView from '@/views/CheckoutView.vue'
import ContactView from '@/views/ContactView.vue'
import DepartmentView from '@/views/DepartmentView.vue'
import HomeView from '@/views/HomeView.vue'
import ProductDetail from '@/views/ProductDetail.vue'
import ProfileView from '@/views/ProfileView.vue'
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
  {
    path: '/pages/about',
    name: 'about',
    component: AboutView
  },
  {
    path: '/pages/contact',
    name: 'contact',
    component: ContactView
  },
  {
    path: '/profile',
    component: ProfileView,
    meta: { requiresAuth: true },

    children: [
      {
        path: '',
        name: 'account', 
        component: Acount
      },
      {
        path: '/profile/changePass',
        name: 'changePass', 
        component: ChangePass
      },
      {
        path: '/profile/orders',
        name: 'order', 
        component: OrderView
      },
      {
        path: '/profile/order/:id',
        name:'orderdetail',
        component: OrderDetail,
        meta: {
          title: 'Chi tiết đơn hàng',
        },
      },
    ]
  },
  {
  path: '/admin',
    component: ()=> import('../views/AdminView.vue'),
    meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
    children: [
      {
        path: '', 
        name: 'adminHome',
        component: ()=> import('../components/chart/ChartView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
      {
        path: 'product',
        name: 'adminProduct', 
        component: ()=> import('../components/admin/Product/ProductView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
      {
        path: 'category',
        name: 'adminCategory', 
        component:()=> import('../components/admin/Category/CategoryView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
      {
        path: 'order',
        name: 'adminOrder', 
        component:()=> import('../components/admin/Order/OrderView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
      {
        path: 'user',
        name: 'adminUser', 
        component:()=> import('../components/admin/User/UserView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
      {
        path: 'news',
        name: 'adminNews', 
        component:()=> import('../components/admin/News/NewsView.vue'),
        meta: { requiresAuth: true , hideNavbar: true , hideFooter: true },
      },
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.meta.title) {
    document.title = to.meta.title;
  }
  next();
});


export default router
