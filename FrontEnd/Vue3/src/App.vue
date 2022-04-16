<template>
  <div>
    <Toast position='top-center' group='main' />
    <router-view />
  </div>
</template>
<script>
import { watch } from 'vue'
import { useStore } from '@/store/store.ts'
import { useToast } from 'primevue/usetoast'

export default {
  components: {},
  setup() {
    localStorage.setItem('theme', 'primevue/resources/themes/vela-blue/theme.css')
    const toast = useToast()
    const store = useStore()
    watch(
      () => store.prop.toastMessage,
      () => {
        toast.add(store.prop.toastMessage)
      }
    )

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