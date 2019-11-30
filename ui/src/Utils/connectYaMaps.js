import loadScript from "./loadScripts";

export default function connectYaMaps(yandexPath) {
  return new Promise((resolve, reject) => {
    if (typeof ymaps !== 'undefined' && ymaps) {
      resolve(ymaps);
    } else {
      loadScript(yandexPath)
        .then(() => resolve(ymaps))
        .catch(reject);
    }
  });
};