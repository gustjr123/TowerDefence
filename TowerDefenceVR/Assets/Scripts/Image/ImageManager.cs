using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject ImagePrefab;
    private GameObject nowImage;
    
    public void ImageSet(Hands hand) {
        nowImage = Instantiate(ImagePrefab, gameObject.transform.position, gameObject.transform.rotation);
        nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    }

    public void ImageSuccess() {
        if (nowImage != null) {
            nowImage.GetComponent<ImageHandle>().Success();
            Destroy(nowImage, 2.0f);
        }
    }
}
