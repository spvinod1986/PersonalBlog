import Vue from 'vue';
import Router from 'vue-router';
import { authGuard } from "./auth/authGuard";
import Home from './components/Home.vue';
import Blog from './components/Blog.vue';
import Create from './components/Create.vue';
import List from './components/List.vue';
import Edit from './components/Edit.vue';


Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/blog/:id',
      name: 'blog',
      component: Blog
    },
    {
      path: '/create',
      name: 'create',
      component: Create,
      beforeEnter: authGuard
    },
    {
      path: '/admin',
      name: 'list',
      component: List,
      beforeEnter: authGuard
    },
    {
      path: '/edit/:id',
      name: 'edit',
      component: Edit,
      beforeEnter: authGuard
    }
  ],
});
