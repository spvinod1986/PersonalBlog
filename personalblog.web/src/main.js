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
import { domain, clientId } from "../auth_config.json"; // Auth0 Configuration - Remember this is not checked in source control 
import { Auth0Plugin } from "./auth"; // Auth0 plugin

// Install the authentication plugin
Vue.use(Auth0Plugin, {
  domain,
  clientId,
  onRedirectCallback: appState => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    );
  }
});

Vue.use(NavbarPlugin);
library.add(faBold, faItalic, faStrikethrough, faUnderline, faCode, faParagraph, faHeading, faList, faListOl, faQuoteRight, faFileCode, faRulerHorizontal, faUndo, faRedo, faTasks, faLink, faWindowClose, faImage);
Vue.component('font-awesome-icon', FontAwesomeIcon);
Vue.component('jw-pagination', JwPagination);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
