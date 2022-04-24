import services from './'
import { useStore } from '@/store/store'
import { EToastSeverity } from '@/Enums/ToastSeverity'

export default (service: string) => {
  const baseUrl = 'api/v1/'
  const store = useStore()

  const getById = async (model) => {
    return await services().get(`${baseUrl + service}/${model.Id}`)
      .then((response) => {
        console.log('getById response', response)
        return response.data
      })
      .catch((error) => {
        console.log('Get: id enviada ->', model.Id)
        console.log('Erro get catch (error)', error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const getAll = async () => {
    return await services()
      .get(`${baseUrl + service}`)
      .then((response) => {
        console.log('getAll response', response)
        return response.data
      })
      .catch((error) => {
        console.log('Get: ALL')
        console.log('Erro getALL catch (error)', error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const saveModel = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
        console.log('SaveModel response', response)
        if (response.status == 200) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Success, 'Sucesso!', 'Salvo em banco de dados', 'main', 2000)
        }
        return response.data
      })
      .catch((error) => {
        console.log('Post: Model enviada ->', model)
        console.log('Erro Save catch (error)', error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const login = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
        console.log('login response', response)
        return response.data
      })
      .catch((error) => {
        console.log('Login: Model enviada ->', model, error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const newPerson = async (model) => {
    return await services()
      .post(`${baseUrl + service}/Cadastro`, model)
      .then((response) => {
        console.log('newPerson response', response)
        if (response.status != 200) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Info, 'Falha!', response.data.detail, 'main', 3000)
        }
        return response.data
      })
      .catch((error) => {
        console.log('NewLogin: Model enviada ->', model, error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const editModel = async (model) => {
    return await services()
      .put(`${baseUrl + service}`, model)
      .then((response) => {
        console.log('editModel response', response)
        if (response.status == 200) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Success, 'Sucesso!', 'Salvo em banco de dados', 'main', 2000)
        }
        return response.data
      })
      .catch((error) => {
        console.log('Put: Model enviada ->', model)
        console.log('Erro Put catch (error)', error.response.data.error)
        console.log(error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  const deleteModel = async (model) => {
    return await services()
      .delete(`${baseUrl + service}/${model.Id}`)
      .then((response) => {
        console.log('deleteModel response', response)
        if (response.status == 200) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Info, 'Deletado com sucesso!', 'Excluido do banco de dados', 'main', 2000)
        }
        return response
      })
      .catch((error) => {
        console.log('Delete: id enviado ->', model.Id)
        console.log('Erro Delete catch (error)', error)
        if (error.response.data.error) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error.response.data.error, 'main', 3000)
        } else {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
        }
      })
  }

  return {
    getAll,
    getById,
    saveModel,
    editModel,
    deleteModel,
    newPerson,
    login
  }
}
