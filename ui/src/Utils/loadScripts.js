export default function loadScript(src) {
  return new Promise(function (resolve, reject) {
      let script = document.createElement('script');
      script.src = src;
      script.addEventListener('load', resolve);
      script.addEventListener('error', (e) => {
          Exceptions.logError(`Не удалось загрузить скрипт. url - ${script.src}`);
          reject(e);
      });
      document.head.appendChild(script);
  });
};