require('./bootstrap')
window.Vue = require('vue')

import Vue from 'vue'
import router from './router';
import VueProgressBar from 'vue-progressbar';
import Vuetify from 'vuetify';
import VeeValidate from 'vee-validate';

//set globally axios
window.axios = require('axios');

//v-validate
Vue.use(VeeValidate)

//vuetify
Vue.use(Vuetify)

//vue progressbar
Vue.use(VueProgressBar, {
    color: '#0063ae',
    failedColor: 'red',
    thickness: '3px',
})

//vue components
Vue.component('AppHome', require('./layouts/AppHome.vue').default);

//new Vue
new Vue({
    el: '#app',
    router
})