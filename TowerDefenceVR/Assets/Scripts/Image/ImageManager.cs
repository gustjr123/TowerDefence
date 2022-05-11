using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftHandImage;
    [SerializeField] private GameObject RightHandImage;
    private GameObject nowImage;
    
    public void ImageSet(Hands hand) {
        nowImage = Instantiate(LeftHandImage, gameObject.transform.position, gameObject.transform.rotation);
        nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    }

    public void ImageSuccess() {
        if (nowImage != null) {
            nowImage.GetComponent<ImageHandle>().Success();
            Destroy(nowImage, 2.0f);
        }
    }

    public void RightImageSet(Hands hand) {
        nowImage = Instantiate(RightHandImage, gameObject.transform.position, gameObject.transform.rotation);
        nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    }
}
