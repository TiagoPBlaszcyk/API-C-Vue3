<template>
  <div>
    <div class='p-d-flex p-justify-center p-align-center p-flex-column' style='height: 100vh'>
      <h1>Cadastro</h1>
      <Button label='Eventos' @click="$router.push({ name: 'Eventos' })" />
    </div>
  </div>
</template>

<script lang='ts'>
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    return {  }
  }
})
</script>
