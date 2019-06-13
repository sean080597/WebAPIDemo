require('./bootstrap')
window.Vue = require('vue')

window.Fire = new Vue()

import Vue from 'vue'
import router from './router';
import VueProgressBar from 'vue-progressbar';
import Vuetify from 'vuetify';
import VeeValidate from 'vee-validate';
import Swal from 'sweetalert2';

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

//Sweet Alert 2
window.Swal = Swal;
const toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});
window.toast = toast;

//vue components
Vue.component('AppHome', require('./layouts/AppHome.vue').default);

//new Vue
new Vue({
    el: '#app',
    router
})