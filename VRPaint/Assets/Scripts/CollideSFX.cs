using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSFX : MonoBehaviour
{

    public AudioClip collided;
    [Range(0.0f, 1.0f)] [SerializeField] float collidedVolume = 0.6f;
    public AudioClip ukulele;
    public AudioClip rocket;
    public AudioClip fan;
    public AudioClip vinyl;
    public AudioClip car;
    public AudioClip radio;
    public AudioClip laptop;
    [Range(0.0f, 1.0f)] [SerializeField] float laptopVolume = 1f;
    public AudioClip tv;
    [Range(0.0f, 1.0f)] [SerializeField] float tvVolume = 1f;
    public AudioClip basketball;
    public AudioClip bag;
    public AudioClip luggage;
    public AudioClip hanger;
    public AudioClip umbrella;
    [Range(0.0f,1.0f)][SerializeField] float umbrellaVolume = 1f;
    public AudioClip lamp;
    public AudioClip alarm;
    public AudioClip darts;
    public AudioClip speaker;
    public AudioClip microwave;
    public AudioClip fridge;
    public AudioClip arcade;
    public AudioClip nintendo;
    public AudioClip clock;
    [Range(0.0f, 1.0f)] [SerializeField] float clockVolume = 0.15f;
    public AudioClip door;
    public AudioClip milk;
    public AudioClip yummy;
    public AudioClip painting;
    public AudioClip plant;
    public AudioClip box;
    public AudioClip switchSFX;
    public AudioClip handBag;
    public AudioClip cup;
    public AudioClip pictures;
    public AudioClip stickies;
    public AudioClip chalk;
    public AudioClip bottle;
    public AudioClip window;
    public AudioClip soccer;
    public AudioClip lullaby;
    public AudioClip weight;
    public AudioClip books;
    public AudioClip wall;
    public AudioClip skate;
    public AudioClip tennis;
    public AudioClip football;
    public AudioClip papers;
    public AudioClip floor;
    public AudioClip wood;
    public AudioClip textil;
    public AudioClip chair;
    public AudioClip bed;
    public AudioClip studyDesk;
    public AudioClip tvFurniture;
    public AudioClip drawerMed;
    public AudioClip ceiling;
    [Range(0.0f, 1.0f)] [SerializeField] float chairVolume = 1f;
    public AudioClip poster;
    [Range(0.0f, 1.0f)] [SerializeField] float posterVolume = 1f;
    public AudioClip pillow;
    [Range(0.0f, 1.0f)] [SerializeField] float pillowVolume = 1f;

    int objectHit = 0;
    public AudioClip combo;
    public AudioClip ultraCombo;
    [Range(0.0f, 1.0f)] [SerializeField] float comboVolume = 0.3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (SetUpText.instance.gameCanStart)
        {
            if (!SetUpText.instance.gameHasEnded)
            {

                AudioSource.PlayClipAtPoint(collided, transform.position, collidedVolume);


                if (collision.collider.name == "06_prop_beer bottle") AudioSource.PlayClipAtPoint(bottle, Camera.main.transform.position);
                else if (collision.collider.name == "01_wall(window)_01") AudioSource.PlayClipAtPoint(window, Camera.main.transform.position);

                CheckIfActivated checkIfActivated = collision.collider.GetComponent<CheckIfActivated>();

                if (checkIfActivated)
                {
                    print("Collided" + checkIfActivated.gameObject.name);
                    if (!checkIfActivated.canPlaySound)
                    {
                        return;
                    }
                }
                else
                {
                    checkIfActivated = collision.collider.transform.parent.GetComponent<CheckIfActivated>();
                  //  print("Collided w parent" + checkIfActivated.gameObject.name);
                    if (!checkIfActivated.canPlaySound)
                    {
                        return;
                    }
                }
                
                switch (collision.collider.tag)
                {
                    case "Ukulele": AudioSource.PlayClipAtPoint(ukulele, transform.position); objectHit++; break;

                    case "Textil": AudioSource.PlayClipAtPoint(textil, Camera.main.transform.position); objectHit++; break;

                    case "Milk": AudioSource.PlayClipAtPoint(milk, transform.position); objectHit++; break;

                    case "Rocket": AudioSource.PlayClipAtPoint(rocket, Camera.main.transform.position); objectHit++; break;

                    case "Fan": AudioSource.PlayClipAtPoint(fan, Camera.main.transform.position); objectHit++; break;

                    case "Vinyl": AudioSource.PlayClipAtPoint(vinyl, Camera.main.transform.position); objectHit++; break;

                    case "Car": AudioSource.PlayClipAtPoint(car, Camera.main.transform.position); objectHit++; break;

                    case "Radio": AudioSource.PlayClipAtPoint(radio, Camera.main.transform.position); objectHit++; break;

                    case "StudyObjects": AudioSource.PlayClipAtPoint(laptop, Camera.main.transform.position, laptopVolume); objectHit++; break;

                    case "TV": AudioSource.PlayClipAtPoint(tv, Camera.main.transform.position, tvVolume); objectHit++; break;

                    case "Basketball": AudioSource.PlayClipAtPoint(basketball, Camera.main.transform.position); objectHit++; break;

                    case "Bag": AudioSource.PlayClipAtPoint(bag, Camera.main.transform.position); objectHit++; break;

                    case "Luggage": AudioSource.PlayClipAtPoint(luggage, Camera.main.transform.position); objectHit++; break;

                    case "Hanger": AudioSource.PlayClipAtPoint(hanger, Camera.main.transform.position); objectHit++; break;

                    case "Umbrella": AudioSource.PlayClipAtPoint(umbrella, Camera.main.transform.position, umbrellaVolume); objectHit++; break;

                    case "Lamp": AudioSource.PlayClipAtPoint(alarm, Camera.main.transform.position); objectHit++; break;

                    case "Wood": AudioSource.PlayClipAtPoint(wood, Camera.main.transform.position); objectHit++; break;

                    case "Alarm": AudioSource.PlayClipAtPoint(alarm, Camera.main.transform.position); objectHit++; break;

                    case "Darts": AudioSource.PlayClipAtPoint(darts, Camera.main.transform.position); objectHit++; break;

                    case "DrawerObejcts": AudioSource.PlayClipAtPoint(speaker, Camera.main.transform.position); objectHit++; break;

                    case "Microwave": AudioSource.PlayClipAtPoint(microwave, Camera.main.transform.position); objectHit++; break;

                    case "Fridge": AudioSource.PlayClipAtPoint(fridge, Camera.main.transform.position); objectHit++; break;

                    case "Arcade": AudioSource.PlayClipAtPoint(arcade, Camera.main.transform.position); objectHit++; break;

                    case "Clock": AudioSource.PlayClipAtPoint(clock, Camera.main.transform.position, clockVolume); objectHit++; break;

                    case "Nitendo": AudioSource.PlayClipAtPoint(nintendo, Camera.main.transform.position); objectHit++; break;

                    case "Door": AudioSource.PlayClipAtPoint(door, Camera.main.transform.position); objectHit++; break;

                    case "yummy": AudioSource.PlayClipAtPoint(yummy, Camera.main.transform.position); objectHit++; break;

                    case "Painting": AudioSource.PlayClipAtPoint(painting, Camera.main.transform.position); objectHit++; break;

                    case "PlantPot": AudioSource.PlayClipAtPoint(plant, Camera.main.transform.position); objectHit++; break;

                    case "PaperBox": AudioSource.PlayClipAtPoint(box, Camera.main.transform.position); objectHit++; break;

                    case "Swich": AudioSource.PlayClipAtPoint(switchSFX, Camera.main.transform.position); objectHit++; break;

                    case "Papers": AudioSource.PlayClipAtPoint(papers, Camera.main.transform.position); objectHit++; break;

                    case "SmallBag": AudioSource.PlayClipAtPoint(handBag, Camera.main.transform.position); objectHit++; break;

                    case "Cup": AudioSource.PlayClipAtPoint(cup, transform.position); objectHit++; break;

                    case "Skateboard": AudioSource.PlayClipAtPoint(skate, transform.position); objectHit++; break;

                    case "Pictures": AudioSource.PlayClipAtPoint(pictures, Camera.main.transform.position); objectHit++; break;

                    case "stickies": AudioSource.PlayClipAtPoint(stickies, Camera.main.transform.position); objectHit++; break;

                    case "Chalk": AudioSource.PlayClipAtPoint(chalk, Camera.main.transform.position); objectHit++; break;

                    case "books": AudioSource.PlayClipAtPoint(books, Camera.main.transform.position); objectHit++; break;

                    case "TennisSofa": AudioSource.PlayClipAtPoint(tennis, Camera.main.transform.position); objectHit++; break;

                    case "chair": AudioSource.PlayClipAtPoint(chair, Camera.main.transform.position, chairVolume); objectHit++; break;

                    case "Poster": AudioSource.PlayClipAtPoint(poster, Camera.main.transform.position, posterVolume); objectHit++; break;

                    case "Pillow": AudioSource.PlayClipAtPoint(pillow, Camera.main.transform.position, pillowVolume); objectHit++; break;

                    case "Football": AudioSource.PlayClipAtPoint(football, Camera.main.transform.position); objectHit++; break;

                    case "Walls": SetUpText.instance.speaker.PlayOneShot(wall); objectHit++; break;

                    case "Floor": SetUpText.instance.speaker.PlayOneShot(wall); objectHit++; break;

                    case "Soccer": AudioSource.PlayClipAtPoint(soccer, Camera.main.transform.position); objectHit++; break;

                    case "Lullaby": AudioSource.PlayClipAtPoint(lullaby, Camera.main.transform.position); objectHit++; break;

                    case "Weight": AudioSource.PlayClipAtPoint(weight, Camera.main.transform.position); objectHit++; break;

                    case "BedPillow": AudioSource.PlayClipAtPoint(bed, Camera.main.transform.position); objectHit++; break;

                    case "StudyDesk": AudioSource.PlayClipAtPoint(studyDesk, Camera.main.transform.position); objectHit++; break;

                    case "tvFurniture": AudioSource.PlayClipAtPoint(tvFurniture, Camera.main.transform.position); objectHit++; break;

                    case "drawerMed": AudioSource.PlayClipAtPoint(drawerMed, Camera.main.transform.position); objectHit++; break;

                    case "TableBed": AudioSource.PlayClipAtPoint(alarm, Camera.main.transform.position); objectHit++; break;

                    case "Ceiling": SetUpText.instance.speaker.PlayOneShot(wall); objectHit++; break;

                }

                if (objectHit >= 5 && objectHit < 7)
                {
                    AudioSource.PlayClipAtPoint(combo, Camera.main.transform.position, comboVolume);
                }
                else if(objectHit >= 7)
                {
                    AudioSource.PlayClipAtPoint(ultraCombo, Camera.main.transform.position, comboVolume);
                }

                checkIfActivated.StartCoroutine("SoundsCD");
            }
           
        }
    }
}
