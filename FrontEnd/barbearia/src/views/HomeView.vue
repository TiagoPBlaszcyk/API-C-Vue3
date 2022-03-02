<template>
  <div class='home'>
    <Button label='Person' @click='goToPerson' />
  </div>
</template>

<script lang='ts'>
import { defineComponent } from 'vue'
import router from '@/router'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    function goToPerson() {
      router.push({ name: 'Cadastro de Pessoas' })
    }

    return { goToPerson }
  }
})
</script>
