<template>
  <div class='home'>
    <p>Meus Produtos</p>
    <div v-for='(prop, name, index) in value' v-bind:key='index'>
      <template v-if="typeof prop == 'number'">
        <p>{{ name }}</p>
        <InputNumber mode='decimal' :minFractionDigits='2' locale='pt-BR' v-model='value[name]' />
      </template>
      <template v-else>
        <p>{{ name }}</p>
        <InputText type='text' v-model='value[name]' />
      </template>
    </div>
    <Button label='Save' @click='submitSave' />
    <Button label='EditPrice' @click='submitEdit' />
    <Button label='Delete' @click='submitDelete' />
    <Button label='console.log(Current)' @click='log' />

    <p>Lista de Produtos no banco</p>
    <p v-for='value in result' :key='value.id'>{{ value }}</p>
  </div>
</template>

<script lang='ts'>
import { defineComponent, onMounted, ref } from 'vue'
import api from '@/service'
import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import { Product } from '@/models/Product'
import Button from 'primevue/button'

export default defineComponent({
  name: 'HomeView',
  components: {
    InputText,
    InputNumber,
    Button
  },
  setup() {
    const result = ref([])
    const value = ref(new Product())

    function update() {
      api.get('api/v1/Product').then((data) => {
        console.log(data)
        result.value = data.data
      })
      value.value = new Product()
    }

    function log() {
      console.log(value.value)
    }

    onMounted(() => {
      update()
    })

    const submitSave = () => {
      api.post('api/v1/Product', value.value).then((data) => {
        result.value.push(data as never)
        update()
      })
    }

    const submitEdit = () => {
      const aux = {
        id: value.value.id,
        name: 'MyNameIs',
        price: 123
      }
      console.log(aux)
      api.put('api/v1/Product', aux).then(() => {
        update()
      })
    }

    const submitDelete = () => {
      api.delete(`api/v1/Product/${value.value.id}`).then(() => {
        update()
      })
    }

    return { result, value, log, submitSave, submitDelete, submitEdit }
  }
})
</script>
