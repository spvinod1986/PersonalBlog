import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vue from 'vue';
import App from './App.vue';
import router from './router';
import { NavbarPlugin } from 'bootstrap-vue'
import { library } from '@fortawesome/fontawesome-svg-core';
import { faBold, faItalic, faStrikethrough, faUnderline, faCode, faParagraph, faHeading, faList, faListOl, faQuoteRight, faFileCode, faRulerHorizontal, faUndo, faRedo, faTasks, faLink, faWindowClose, faImage } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import JwPagination from 'jw-vue-pagination';
// Auth0 Configuration - Remember auth_config.json is not checked in source control 
// It has following details
// {
//   "domain": "",
//   "clientId": "",
//   "audience": ""
// }
import { domain, clientId, audience } from "../auth_config.json";
import { Auth0Plugin } from "./auth"; // Auth0 plugin
import VueMoment from 'vue-moment'

// Install the authentication plugin
Vue.use(Auth0Plugin, {
  domain,
  clientId,
  audience,
  onRedirectCallback: appState => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    );
  }
});

Vue.use(NavbarPlugin);
Vue.use(VueMoment);
library.add(faBold, faItalic, faStrikethrough, faUnderline, faCode, faParagraph, faHeading, faList, faListOl, faQuoteRight, faFileCode, faRulerHorizontal, faUndo, faRedo, faTasks, faLink, faWindowClose, faImage);
Vue.component('font-awesome-icon', FontAwesomeIcon);
Vue.component('jw-pagination', JwPagination);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
