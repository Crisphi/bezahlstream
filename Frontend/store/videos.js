export const state = () => ({
  videos: [
    {
      id: 1,
      name: 'Video 1',
      type: 'video/mp4',
      url:
        'https://cdn.theguardian.tv/webM/2015/07/20/150716YesMen_synd_768k_vp8.webm'
    },
    {
      id: 2,
      name: 'Video 2',
      type: 'video/mp4',
      url:
        'https://cdn.theguardian.tv/webM/2015/07/20/150716YesMen_synd_768k_vp8.webm'
    }
  ]
})

export const getters = {
  get: (state) => {
    return state.videos
  }
}
