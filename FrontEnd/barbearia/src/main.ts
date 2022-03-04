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
import InputMask from 'primevue/inputmask'
import Password from 'primevue/password'
import Divider from 'primevue/divider'


import '/node_modules/primevue/resources/themes/vela-blue/theme.css'
import '/node_modules/primevue/resources/primevue.min.css'
import '/node_modules/primeflex/primeflex.css'
import '/node_modules/primeicons/primeicons.css'

createApp(App)
  .use(router)
  .use(VueAxios, axios)
  .use(PrimeVue, {ripple: true})
  .directive('ripple', Ripple)
  .directive('styleclass', StyleClass)
  .component('InputText', InputText)
  .component('InputMask', InputMask)
  .component('InputNumber', InputNumber)
  .component('Listbox', Listbox)
  .component('Button', Button)
  .component('Password', Password)
  .component('Divider', Divider)
  .mount('#app')
