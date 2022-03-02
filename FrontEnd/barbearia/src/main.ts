import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'

import PrimeVue from 'primevue/config'
import StyleClass from 'primevue/styleclass'
import Ripple from 'primevue/ripple'
import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import Listbox from 'primevue/listbox'
import Button from 'primevue/button'

import 'primevue/resources/themes/vela-blue/theme.css'
import 'primevue/resources/primevue.min.css'
import 'primeflex/primeflex.css'
import 'primeicons/primeicons.css'

createApp(App)
  .use(router)
  .use(PrimeVue, {ripple: true})
  .component('InputText', InputText)
  .component('InputNumber', InputNumber)
  .component('Listbox', Listbox)
  .component('Button', Button)
  .directive('styleclass', StyleClass)
  .directive('ripple', Ripple)
  .use(VueAxios, axios)
  .use(PrimeVue).
mount('#app')
