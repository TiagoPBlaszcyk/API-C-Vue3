<template>
  <div class='home'>
    <p>Tes</p>
    <div v-for='(prop, name, index) in current' :key='index'>
      <template v-if="typeof prop == 'number' || name === 'id'">
        <p>{{ name }}</p>
        <InputNumber mode='decimal' :minFractionDigits='2' :min='0' locale='pt-BR' v-model.number='current[name]' :allow-empty='false' />
      </template>
      <template v-else>
        <p>{{ name }}</p>
        <InputText type='text' v-model='current[name]' />
      </template>
    </div>
    <Button label='Save' @click='personSave(current)' />
    <Button label='EditPrice' @click='personEdit(current)' />
    <Button label='Delete' @click='personDelete(current.id)' />
    <Button label='UpdateList' @click='update()' />

    <p>Lista de Produtos no banco</p>
    <p v-for='value in list' :key='value.id'>{{ value }}</p>
  </div>
</template>

<script lang='ts'>
import { defineComponent, onMounted, ref } from 'vue'
import InputText from 'primevue/inputtext'
import InputNumber from 'primevue/inputnumber'
import { Person } from '@/models/Person'
import Button from 'primevue/button'
import api from '@/service'

export default defineComponent({
  name: 'HomeView',
  components: {
    InputText,
    InputNumber,
    Button
  },
  setup() {
    const current = ref<Person>(new Person())
    const list = ref<Array<Person>>([])

    onMounted(() => {
      update()
    })
    function update(){
      try {
        api.get('api/v1/Person').then((data) => {
          list.value = data.data as Array<Person>
        }).catch((response) => {
          console.log('Erro personGetAll:', response)
          Promise.reject(response)
        })
      } catch (response) {
        console.log('Erro personGetAll:', response)
      }
    }

    // function personGetById(value) {
    //   try {
    //     api.get(`api/v1/Person/${value}`, ).then((data) => {
    //      current.value = data.data as Person
    //     }).catch((response) => {
    //       console.log('Erro personGetById:', response)
    //       Promise.reject(response)
    //     })
    //   } catch (response) {
    //     console.log('Erro personGetById:', response)
    //   }
    // }

    function personSave(value) {
      try {
        api.post('api/v1/Person', value).then(() => {
          // return data.data as Person
          Promise.resolve()
        }).catch((response) => {
          console.log('Erro personSave:', response)
          Promise.reject(response)
        })
      } catch (response) {
        console.log('Erro personSave:', response)
      }
    }

    function personEdit(value) {
      try {
        api.put('api/v1/Person', value).then(() => {
          // return data.data as Person
          Promise.resolve()
        }).catch((response) => {
          console.log('Erro personEdit:', response)
          Promise.reject(response)
        })
      } catch (response) {
        console.log('Erro personEdit:', response)
      }
    }

    function personDelete(value) {
      try {
        api.delete(`api/v1/Person/${value}`).then(() => {
          Promise.resolve()
        }).catch((response) => {
          console.log('Erro personDelete:', response)
          Promise.reject(response)
        })
      } catch (response) {
        console.log('Erro personDelete:', response)
      }
    }

    return { current, list, personDelete, personSave, personEdit, update }
  }
})
</script>
