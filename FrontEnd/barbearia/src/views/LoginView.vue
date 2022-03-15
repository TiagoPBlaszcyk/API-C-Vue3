<template>
  <div class='p-d-flex p-jc-center p-align-center p-flex-column'>
    <div>
      <h1 class='p-text-center p-mb-6'>Login</h1>
      <div class=''>
        <div class='p-inputgroup p-mt-4'>
          <span class='p-inputgroup-addon'><i class='pi pi-user'></i></span>
          <span class='p-float-label'>
              <InputText id='inputname' type='text' v-model='state.name' />
              <label for='inputname'>Nome*</label>
            </span>
        </div>
      </div>
      <div :class="{ 'p-error': v$.$invalid }" v-if='v$.name'>
        <div v-for='error of v$.name.$silentErrors' :key='error.$message'>
          {{ error.$message }}
        </div>
      </div>
      <div class=''>
        <div class='p-inputgroup p-mt-4'>
          <span class='p-inputgroup-addon'><i class='pi pi-key'></i></span>
          <span class='p-float-label'>
              <Password id='inputsenha' v-model='state.senha' :weakLabel='`Senha Fraca`' :mediumLabel='`Senha normal`'
                        :strongLabel='`Senha Forte`' toggleMask>
                <template #header>
                  <h3>Nivel de segurança</h3>
                </template>
                <template #footer='sp'>
                  {{ sp.level }}
                  <Divider></Divider>
                  <p class='mt-2'>Sugestão</p>
                  <ul class='pl-2 ml-2 mt-0' style='line-height: 1.5'>
                    <li>Ao menos 1 caractere minusculo</li>
                    <li>Ao menos 1 caractere MAIUSCULO</li>
                    <li>Ao menos 1 número</li>
                    <li>Ao menos 8 characters</li>
                  </ul>
                </template>
              </Password>
              <label for='inputsenha'>Senha*</label>
            </span>
        </div>
      </div>
      <div :class="{ 'p-error': v$.$invalid }" v-if='v$.senha'>
        <div v-for='error of v$.senha.$silentErrors' :key='error.$message'>
          {{ error.$message }}
        </div>
      </div>
      <div class=''>
        <div class='p-inputgroup p-mt-4'>
          <span class='p-inputgroup-addon'><i class='pi pi-key'></i></span>
          <span class='p-float-label'>
              <Password id='inputconfirmarSenha' v-model='state.confirmarSenha' :feedback='false' toggleMask />
              <label for='inputconfirmarSenha'>Confirme a Senha*</label>
            </span>
        </div>
      </div>
      <div :class="{ 'p-error': v$.$invalid }" v-if='v$.confirmarSenha'>
        <div v-for='error of v$.confirmarSenha.$silentErrors' :key='error.$message'>
          {{ error.$message }}
        </div>
      </div>
    </div>
    <div>
      <Button
        icon='pi pi-sign-in'
        iconPos='right'
        class='p-m-2'
        label='Entrar'
        @click='login()'
      />
    </div>
  </div>
</template>

<script lang='ts'>
import { computed, defineComponent, inject, reactive } from 'vue'
import { helpers, required, sameAs } from '@vuelidate/validators'
import useVuelidate from '@vuelidate/core'
import baseService from '@/service/base.service'
import router from '@/router'

export default defineComponent({
  name: 'LoginView',
  components: {},
  setup() {
    const storage = inject('storage')
    const controller = 'Login'
    const state = reactive({
      name: null,
      senha: null,
      confirmarSenha: null
    })
    const rules = computed(() => ({
      name: {
        required: helpers.withMessage('Digite admin', required)
      },
      senha: {
        required: helpers.withMessage('Digite admin', required)
      },
      confirmarSenha: {
        required: helpers.withMessage('Preenchimento obrigatório', required),
        sameAs: helpers.withMessage('As senhas digitadas não são iguais', sameAs(state.senha))
      }
    }))
    const v$ = useVuelidate(rules, state)

    const login = async () => {
      await baseService(controller)
        .login(
          {
            Name: state.name,
            Senha: state.senha
          }
        )
        .then((result) => {
          if(result.token){
            localStorage.setItem('Authorization', result.token)
            router.push('/Home')
          } else {
            localStorage.clear()
            router.push('/')
          }
        })
    }

    return {
      storage,
      v$,
      state,
      login
    }
  }
})
</script>

<style scoped>
::v-deep(.p-password input) {
  width: 15rem;
}
</style>