<template>
  <div>
    <div v-for='(prop, name, index) in current' :key='index'>
      <p class='py-6'>{{ name }} tem {{ prop }}</p>
      <InputText type='text' v-model='current[name]' />
    </div>
    <br>
    <Button label='Save' @click='personSave(current)' />
    <Button label='EditPrice' @click='personEdit(current)' />
    <Button label='Delete' @click='personDelete(current)' />
    <hr>
    <p>Lista de Produtos no banco</p>
    <Button label='UpdateList' @click='getAll()' />
    <Listbox :options='list' optionLabel='name' @change="change($event)"/>
  </div>
</template>

<script lang='ts'>
import { defineComponent, onMounted, ref } from 'vue'
import { Person } from '@/models/Person'
import baseService from '@/service/base.service'
import router from '@/router'

export default defineComponent({
  name: 'personView',
  components: {},
  setup() {
    const current = ref<Person>(new Person(undefined,'InsertName', 0,'','',''))
    const list = ref<Array<Person>>([])
    const controller = router.currentRoute.value.path.substring(1)

    onMounted(async () => {
      await getAll()
    })

    async function getAll() {
      (await baseService(controller)).getAll().then((data) => {
        list.value = data as Array<Person>
      }).catch((response) => {
        console.log('Erro personGetAll:', response)
        Promise.reject(response)
      })
    }

    async function personSave(value: Person) {
      await (await baseService(controller)).saveModel(value)
    }

    async function personEdit(value: Person) {
      await (await baseService(controller)).editModel(value)
    }

    async function personDelete(value: Person) {
      await (await baseService(controller)).deleteModel(value)
    }

    async function change(event) {
       await (await baseService(controller)).deleteModel(event.value)
    }
    return { current, list, change, personDelete, personSave, personEdit, getAll }
  }
})
</script>

<style scoped>

</style>