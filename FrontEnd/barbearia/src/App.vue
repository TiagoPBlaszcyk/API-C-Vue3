<template>
  <router-view />
</template>
<script>
import { provide } from 'vue'
import storage from '@/store/storage.ts'

export default {
  components: {},
  setup() {
    localStorage.setItem('theme', 'primevue/resources/themes/vela-blue/theme.css')
    provide('storage', storage)
    return {}
  }
}
</script>

<style>
body {
  margin: 0;
  height: 100%;
  overflow-x: hidden;
  overflow-y: auto;
  background-color: var(--surface-a);
  font-family: var(--font-family);
  font-weight: 400;
  color: var(--text-color);
}

</style>