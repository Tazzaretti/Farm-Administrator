import { toast } from 'react-toastify'

const useNotify = () => {
    const successMessage = (message) => {
        toast.success(message, {
          position: 'bottom-center',
          autoClose: 5000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'dark'
        })
      }
    
      const errorMessage = (message) => {
        toast.error(message, {
          position: 'bottom-center',
          autoClose: 5000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: 'dark',
        })
      }
  return {
    successMessage,
    errorMessage
  }
}

export default useNotify