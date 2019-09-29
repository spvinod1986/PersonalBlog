import Vue from 'vue';
import Router from 'vue-router';
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
      component: Create
    },
    {
      path: '/list',
      name: 'list',
      component: List
    },
    {
      path: '/edit/:id',
      name: 'edit',
      component: Edit
    }
  ],
});
