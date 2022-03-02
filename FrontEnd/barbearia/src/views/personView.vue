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
    <p>GetByID input id com System.Threading.Thread.Sleep(5000); no back end</p>
    <Button label='GetById' @click='personGet(testeId)' />
    <InputNumber mode='decimal' v-model.number='testeId'></InputNumber>
    <p>Resul GetByID > {{result}}</p>
    <hr>
    <p>Lista de Produtos no banco</p>
    <Button label='UpdateList' @click='getAll()' />
    <p v-for='value in list' :key='value.id'>{{ value }}</p>
  </div>
</template>

<script lang='ts'>
import { defineComponent, onMounted, ref } from 'vue'
import { Person } from '@/models/Person'
import baseService from '@/service/base.service'

export default defineComponent({
  name: 'personView',
  components: {},
  setup() {
    const current = ref<Person>(new Person())
    const testeId = ref(19)
    const result = ref( )
    const list = ref<Array<Person>>([])
    const controller = 'Person'

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

    async function personGet(value) {
      await (await baseService(controller)).getById(value).then((data) => {
        result.value = data as Person
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

    return { current, result, list, personDelete, personGet, personSave, personEdit, getAll, testeId }
  }
})
</script>

<style scoped>

</style>