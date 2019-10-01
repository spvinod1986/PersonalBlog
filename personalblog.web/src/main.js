import 'bootstrap/dist/css/bootstrap.css';
import Vue from 'vue';
import CKEditor from '@ckeditor/ckeditor5-vue';
import App from './App.vue';
import router from './router';

Vue.config.productionTip = false;
Vue.use(CKEditor);

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
