import axios, { AxiosInstance } from 'axios'

const api: AxiosInstance = axios.create({
  baseURL: 'http://localhost:5021/',
  headers: {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': true,
    Authorization: ''
  },
  timeout: 60 * 1000
})

export default api
