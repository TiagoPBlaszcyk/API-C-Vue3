import services from './'

export default (service: string) => {
  const baseUrl = 'api/v1/'

  const getById = async (model) => {
    return await services().get(`${baseUrl + service}/${model.Id}`)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Get: id enviada ->', model.Id)
        console.log('Erro get catch (error)', error.response)
      })
  }

  const getAll = async () => {
    return await services()
      .get(`${baseUrl + service}`)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Get: ALL')
        console.log('Erro getALL catch (error)', error.response)
      })
  }

  const saveModel = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
          console.log(response)
          return response.data
        })
      .catch((error) => {
        console.log('Post: Model enviada ->', model)
        console.log('Erro Save catch (error)', error.response)
      })
  }

  const login = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
        return response.data
      })
      .catch(() => {
        console.log('Post: Model enviada ->', model)
        alert('Tente Novamente!')
      })
  }

  const newPerson = async (model) => {
    return await services()
      .post(`${baseUrl + service}/Cadastro`, model)
      .then((response) => {
        console.log(response)
        return response.data
      })
      .catch(() => {
        console.log('Post: Model enviada ->', model)
        alert('Tente Novamente!')
      })
  }

  const editModel = async (model) => {
    console.log('editModel', model)
    return await services()
      .put(`${baseUrl + service}`, model)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Put: Model enviada ->', model)
        console.log('Erro Put catch (error)', error.response)
      })
  }

  const deleteModel = async (model) => {
    return await services()
      .delete(`${baseUrl + service}/${model.Id}`)
      .then((r) => {
        return r
      })
      .catch((error) => {
        console.log('Delete: id enviado ->', model.Id)
        console.log('Erro Delete catch (error)', error.response)
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