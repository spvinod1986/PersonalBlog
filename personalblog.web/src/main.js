import 'bootstrap/dist/css/bootstrap.css';
import Vue from 'vue';
import App from './App.vue';
import router from './router';

import { library } from '@fortawesome/fontawesome-svg-core';
import { faBold, faItalic, faStrikethrough, faUnderline, faCode, faParagraph, faHeading, faList, faListOl, faQuoteRight, faFileCode, faRulerHorizontal, faUndo, faRedo, faTasks, faLink, faWindowClose, faImage } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

library.add(faBold, faItalic, faStrikethrough, faUnderline, faCode, faParagraph, faHeading, faList, faListOl, faQuoteRight, faFileCode, faRulerHorizontal, faUndo, faRedo, faTasks, faLink, faWindowClose, faImage);
Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
