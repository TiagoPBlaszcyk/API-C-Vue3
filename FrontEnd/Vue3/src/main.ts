import { createApp } from 'vue'
import { ptBr } from '@/translations/ptBr'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'

import PrimeVue from 'primevue/config'
import ConfirmationService from 'primevue/confirmationservice'
import ToastService from 'primevue/toastservice'
import StyleClass from 'primevue/styleclass'
import Ripple from 'primevue/ripple'
import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import Listbox from 'primevue/listbox'
import Dropdown from 'primevue/dropdown'
import DataTable from 'primevue/datatable'
import Calendar from 'primevue/calendar'
import Column from 'primevue/column'
import Button from 'primevue/button'
import Sidebar from 'primevue/sidebar'
import Checkbox from 'primevue/checkbox'
import InputMask from 'primevue/inputmask'
import InputSwitch from 'primevue/inputswitch'
import Password from 'primevue/password'
import Divider from 'primevue/divider'
import ConfirmDialog from 'primevue/confirmdialog'
import Toast from 'primevue/toast'


import '/node_modules/primevue/resources/themes/vela-blue/theme.css'
import '/node_modules/primevue/resources/primevue.min.css'
import '/node_modules/primeflex/primeflex.css'
import '/node_modules/primeicons/primeicons.css'

createApp(App)
  .use(createPinia())
  .use(router)
  .use(VueAxios, axios)
  .use(PrimeVue, {
    locale: ptBr,
    ripple: true,
    zIndex: {
      modal: 1100,        //dialog, sidebar
      overlay: 1000,      //dropdown, overlaypanel
      menu: 1000,         //overlay menus
      tooltip: 1200       //tooltip
    }
  })
  .use(ConfirmationService)
  .use(ToastService)
  .directive('ripple', Ripple)
  .directive('styleclass', StyleClass)
  .component('Calendar', Calendar)
  .component('InputText', InputText)
  .component('InputMask', InputMask)
  .component('InputNumber', InputNumber)
  .component('InputSwitch', InputSwitch)
  .component('Dropdown', Dropdown)
  .component('Sidebar', Sidebar)
  .component('ConfirmDialog', ConfirmDialog)
  .component('DataTable', DataTable)
  .component('Column', Column)
  .component('Toast', Toast)
  .component('Checkbox', Checkbox)
  .component('Listbox', Listbox)
  .component('Button', Button)
  .component('Password', Password)
  .component('Divider', Divider)
  .mount('#app')

// TODO: Abstract fetch
// TODO: Home