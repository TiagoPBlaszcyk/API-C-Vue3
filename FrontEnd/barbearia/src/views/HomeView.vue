<template>
  <div class='p-d-flex p-justify-center p-align-center p-flex-column' style='height: 100vh'>
    <h1>Cadastro</h1>
    <Button label='Person' @click="$router.push({ name: 'Cadastro de Pessoas' })" />
  </div>
</template>

<script lang='ts'>
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    return { }
  }
})
</script>
